using System.Data;
using System.Threading.Tasks;
using Sappfir2.Extensions;
using Sappfir2.Views.NsStation;

namespace Sappfir2.ViewModels.NsStation {
	public class NsStationCollectionViewModel : SappfirDatatableViewModelCollectionWithChildView<NsStationView, string> {
		public DataSet Data { get; } = new DataSet();

		public NsStationCollectionViewModel() {
			Entities.TableName = "NsStation";
			Entities.Columns.Add("StationCode", typeof(string));
			Data.Tables.Add(Entities);
		}

		public override async Task RefreshCore() {
			Entities.Clear();

			var depots = await Db.GetData("SELECT * from NsStation", WindowCancellationToken);

			Entities.CopyFrom(depots);
		}

		protected override string GetDataRowKey(DataRowView row) {
			return row["StationCode"] as string;
		}
	}
}