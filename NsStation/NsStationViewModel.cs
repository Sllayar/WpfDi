using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sappfir2.ViewModels.NsStation {
	public class NsStationViewModel : SappfirViewModelEntity<Core.Model.NsStation, string> {
		//public IEnumerable<Core.Model.NsRailroad> NsRailroad { get; set; }
		//public IEnumerable<Core.Model.NsDepartment> NsDepartment { get; set; }
		private Core.Model.NsStation tempStation;
		private Core.Model.NsStation entry;
		protected override async Task OnLoadedCore() {
			if(string.IsNullOrEmpty(EntityId)) {
				tempStation = new Core.Model.NsStation() { StationCode = "000000" };
				await Db.NsStation.AddAsync(tempStation, WindowCancellationToken);
				InitEntity(tempStation);
			}
			else {
				entry = await Db.NsStation.Where(m => m.StationCode == EntityId).FirstOrDefaultAsync(WindowCancellationToken);
				InitEntity(entry);
			}
			//NsRailroad = await Db.NsRailroad.ToListAsync(CancellationToken);
			//NsDepartment = await Db.NsDepartment.ToListAsync(CancellationToken);
		}
		public override async Task<bool> SaveCore() {
			if(tempStation != null) {
				Db.Entry(tempStation).State = EntityState.Detached;
				var entry = (Core.Model.NsStation)tempStation.Clone();
				await Db.NsStation.AddAsync(tempStation, WindowCancellationToken);
				InitEntity(entry);
			}
			await Db.SaveChangesAsync(WindowCancellationToken);
			EntityId = Entity.StationCode;
			return true;
		}

		public override async Task<bool> DeleteCore() {
			Db.NsStation.Remove(Entity);
			await Db.SaveChangesAsync(WindowCancellationToken);
			return true;
		}
		//public override bool CanSave() => Db.ChangeTracker.HasChanges() && !IsProcessing && !IsSomeCommandExecuting();
		//public override bool CanReset() => Db.ChangeTracker.HasChanges() && !IsProcessing && !IsSomeCommandExecuting();
		public override bool CanDelete() => EntityId != string.Empty && !IsProcessing;
	}
}