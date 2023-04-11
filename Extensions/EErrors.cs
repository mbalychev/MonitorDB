using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MonitorDB.Readers;
using Pp.Common.FilesDb;
using Pp.Common.FilesDb.Models;

namespace MonitorDB.Extensions
{
    public static class EErrors
    {
        private static FilesDbContext db { get; set; }
        private static ICollection<TApplication> applicationsNames { get; set; } = new List<TApplication>();
        private static ICollection<TResultsType> resultsNames { get; set; } = new List<TResultsType>();

        public static async Task<ICollection<ErrorsQueryResults>> ConvertToModels(this ICollection<TResult> results, FilesDbContext context)
        {
            db = context;
            applicationsNames = await ApplicationsAsync();
            resultsNames = await TypesAsync();

            ICollection<ErrorsQueryResults> models = new List<ErrorsQueryResults>();
            foreach (TResult result in results)
            {
                ErrorsQueryResults model = new ErrorsQueryResults
                {
                    TRId = result.TRId,
                    TRFile = result.TRFile,
                    TRFileSource = result.TRFileSource,
                    TRType = result.TRType,
                    TRApplication = result.TRApplication,
                    TRDateCreate = result.TRDateCreate,
                    ApplicationsName = applicationsNames.Where(x => x.TAId == result.TRApplication).Select(x => x.TAName).FirstOrDefault(),
                    ResultName = resultsNames.Where(x => x.TRTId == result.TRType).Select(x => x.TRTName).FirstOrDefault(),
                };

                models.Add(model);
            }
            return models;
        }

        private static async Task<ICollection<TApplication>> ApplicationsAsync()
        {
            //приложения коды + описание
            ICollection<TApplication> apps = await db.TApplications.ToListAsync();
            return apps;
        }

        private static async Task<ICollection<TResultsType>> TypesAsync()
        {
            ICollection<TResultsType> resTypes = await db.TResultsTypes.ToListAsync();
            return resTypes;
        }
    }
}