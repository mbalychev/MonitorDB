using Microsoft.EntityFrameworkCore;
using MonitorDB.Extensions;
using Pp.Common.FilesDb;
using Pp.Common.FilesDb.Models;

namespace MonitorDB.Readers
{
    public class ReadXmlErrors
    {
        //приложения
        private short[] appllications = new short[] { 10020, 10100, 10080, 10400, 10070 };
        //типы файлов
        private short[] types = new short[] { 10020, 10100, 10080, 10400, 10070, 10010, 10060, 10200, 10300 };
        private readonly IDbContextFactory<FilesDbContext> fileContext;
        public ReadXmlErrors(
            IDbContextFactory<FilesDbContext> _fileContext)
        {
            this.fileContext = _fileContext;
        }

        public async Task<IEnumerable<ErrorsQueryResults>?> Read()
        {
            using FilesDbContext db = await fileContext.CreateDbContextAsync();
            try
            {
                //табл чистого результат
                ICollection<TResult> results = await db.TResults.FromSqlRaw(ErrorsQuery.Query).ToListAsync();
                IEnumerable<ErrorsQueryResults> models = await results.ConvertToModels(db);

                return models;
            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
}