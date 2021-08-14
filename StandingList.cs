using System;
using System.Collections;
using System.Data;
using System.IO;

namespace EVE_Mission_Counter
{
  public class StandingList
  {
    private XMLStanding xmlStanding;
    private string m_name;
    private bool m_xsdValid;

    public StandingList(string filePath, bool validateXsd = false, string xsd = "")
    {
      this.xmlStanding = new XMLStanding(filePath, validateXsd, xsd);
      this.m_name = Path.GetFileNameWithoutExtension(filePath);
      this.m_xsdValid = this.xmlStanding.Status == XMLStanding.State.VALID;
    }

    public Standing GetStanding(string faction)
    {
      DataRow dataRow = this.xmlStanding.Select(faction);
      Standing standing = (Standing) null;
      if (dataRow != null)
      {
        standing = new Standing();
        standing.Faction = dataRow[nameof (faction)] != DBNull.Value ? dataRow[nameof (faction)].ToString() : string.Empty;
        standing.Level1 = dataRow["level1"] != DBNull.Value ? Convert.ToInt32(dataRow["level1"]) : 0;
        standing.Level2 = dataRow["level2"] != DBNull.Value ? Convert.ToInt32(dataRow["level2"]) : 0;
        standing.Level3 = dataRow["level3"] != DBNull.Value ? Convert.ToInt32(dataRow["level3"]) : 0;
        standing.Level4 = dataRow["level4"] != DBNull.Value ? Convert.ToInt32(dataRow["level4"]) : 0;
        standing.Level5 = dataRow["level5"] != DBNull.Value ? Convert.ToInt32(dataRow["level5"]) : 0;
      }
      return standing;
    }

    public ArrayList GetStandingList(string filter = "")
    {
      if (filter == "" || filter == "<all>")
        return this.xmlStanding.SelectAll();
      return new ArrayList()
      {
        (object) this.GetStanding(filter)
      };
    }

    public ArrayList GetFactionList() => this.xmlStanding.GetKeys();

    public void UpdateStanding(string faction, string level, int value) => this.xmlStanding.Update(faction, level, value);

    public string Name => this.m_name;

    public bool ValidXsd => this.m_xsdValid;
  }
}
