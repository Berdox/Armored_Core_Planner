using Microsoft.EntityFrameworkCore;

namespace armored_core_planner.Data {
    public class ApplicationDbContext :DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}
