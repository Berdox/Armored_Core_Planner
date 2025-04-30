using armored_core_planner.Data;

namespace armored_core_planner.Services {
    public class ExcelImportService {
        private readonly ApplicationDbContext _context;

        public ExcelImportService(ApplicationDbContext context) {
            _context = context;
        }

        /*public async Task ImportItemsFromExcelAsync(Stream excelStream) {
            // 1. Open Excel
            // 2. Parse rows
            // 3. Map rows into Item objects
            // 4. Save them into database (_context.Items.AddRangeAsync)
            // 5. SaveChangesAsync
        }*/
    }
}
