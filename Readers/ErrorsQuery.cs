namespace MonitorDB.Readers
{
    public static class ErrorsQuery
    {
        public static string Query
        {
            get =>
       @"begin;
           select * from(
	    with devapps as (
			select * from (
				values 
				(1021), -- DEV Queue Builder by Sergey
				(1031), -- DEV Contact Queue Builder by Sergey
				(1101), -- DEV Nalogru XML worker
				(2001) -- DEV Pp.Dataloader.Xml
			) as v (app)
			union all
			select ""tA_ID"" app from ""tApplications"" where ""tA_Parent"" = 2001 -- все прямые потомки приложения `DEV Pp.Dataloader.xml`
        )
        select tr1.*, a.""tA_Name"", r.""tRT_Name""  from ""tResults"" tr1
		-- Поиск события `исправления` ошибки
        left join ""tResultsTypes"" r on r.""tRT_ID"" = tr1.""tR_Type"" 
		left join ""tApplications"" a on a.""tA_ID"" = tr1.""tR_Application"" 
        left join ""tResults"" tr2 on
            tr2.""tR_File"" = tr1.""tR_File""
            and tr2.""tR_ID"" != tr1.""tR_ID""
            and tr2.""tR_Application"" = tr1.""tR_Application""
            and tr2.""tR_FileSource"" = tr1.""tR_FileSource""
            and tr2.""tR_DateCreate"" >= tr1.""tR_DateCreate""
            -- типы событий, которые могут считаться за `исправление`
			and tr2.""tR_Type"" in (
                10020, --ОК
                10100, --Файл обработан ранее
                10080, --Файл обработан
                10400, --Файл с 0 размером пропущен
                10070-- Файлы в архиве обработаны
			)
			and tr1.""tR_Application"" not in (select * from devapps)
        where
            tr1.""tR_DateCreate"" >= (now() - '24:00:00'::interval)
            -- типы событий, которые считаем ошибкой
            and tr1.""tR_Type"" in (
                10010, --ERROR
                10060, --Не удалось открыть архив
                10200, --Ожидает ручной проверки
                10300-- Физический файл не найден
			)
            and tr1.""tR_Application"" not in (select * from devapps)
            and tr2.""tR_ID"" is null
	) as res;
            end; 
            ";
        }
    }
}