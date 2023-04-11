using System.Text.Json.Serialization;

namespace MonitorDB.Readers
{
    public class ErrorsQueryResults
    {
        //
        // Сводка:
        //     ID записи
        [JsonPropertyName("id")]
        public long TRId { get; set; }
        //
        // Сводка:
        //     ID родительского результата
        [JsonPropertyName("parentId")]
        public long? TRParent { get; set; }
        //
        // Сводка:
        //     ID результирующего файла
        [JsonPropertyName("fileId")]
        public long TRFile { get; set; }
        //
        // Сводка:
        //     Id источника (необходим в целях секционирования)
        [JsonPropertyName("fileSourceId")]
        public short TRFileSource { get; set; }
        //
        // Сводка:
        //     ID типа результата
        [JsonPropertyName("typeId")]
        public short TRType { get; set; }
        //
        // Сводка:
        //     Привязка результата к приложению
        [JsonPropertyName("appId")]
        public short TRApplication { get; set; }
        //
        // Сводка:
        //     Комментарий
        [JsonPropertyName("comment")]
        public string TRComment { get; set; } = string.Empty;
        //
        // Сводка:
        //     Тех. дата результата
        [JsonPropertyName("techData")]
        public string TRTechData { get; set; } = string.Empty;
        //
        // Сводка:
        //     Время записи результата
        [JsonPropertyName("dateCreate")]
        public DateTime TRDateCreate { get; set; }
        [JsonPropertyName("app")]
        public string? ApplicationsName { get; set; } = string.Empty;
        [JsonPropertyName("result")]
        public string? ResultName { get; set; } = string.Empty;
    }
}