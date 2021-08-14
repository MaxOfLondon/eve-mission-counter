using System.Collections;
using System.Data;
using System.IO;
using System.Xml.Schema;

namespace EVE_Mission_Counter
{
  public sealed class XMLStanding
  {
    private string m_filePath;
    private DataSet m_ds;
    private DataView m_dv;
    private string m_xsd;
    public XMLStanding.State Status;

    public XMLStanding(string filePath, bool validateXsd = false, string xsd = "")
    {
      this.m_filePath = filePath;
      this.m_xsd = xsd;
      if (validateXsd)
        this.ValidateXsd();
      this.m_ds = new DataSet();
      int num = (int) this.m_ds.ReadXml(this.m_filePath, XmlReadMode.ReadSchema);
      this.m_dv = new DataView();
      this.m_dv = this.m_ds.Tables[0].DefaultView;
    }

    private void ValidateXsd()
    {
      DataSet dataSet1 = new DataSet();
      DataSet dataSet2 = new DataSet();
      dataSet1.ReadXmlSchema(this.m_filePath);
      StringReader stringReader = new StringReader(this.m_xsd);
      dataSet2.ReadXmlSchema((TextReader) stringReader);
      if (dataSet1.Tables[0].TableName == dataSet2.Tables[0].TableName)
      {
        foreach (DataColumn column in (InternalDataCollectionBase) dataSet1.Tables[0].Columns)
        {
          if (!dataSet2.Tables[0].Columns.Contains(column.Caption))
          {
            this.Status = XMLStanding.State.INVALID;
            return;
          }
        }
        this.Status = XMLStanding.State.VALID;
      }
      else
        this.Status = XMLStanding.State.INVALID;
    }

    public void Save() => this.m_ds.WriteXml(this.m_filePath, XmlWriteMode.WriteSchema);

    public void Update(string faction, string level, int value)
    {
      this.Select(faction)[level] = (object) value;
      this.Save();
    }

    public DataRow Select(string faction)
    {
      this.m_dv = this.m_ds.Tables[0].DefaultView;
      this.m_dv.RowFilter = "faction='" + faction + "'";
      DataRow dataRow = (DataRow) null;
      if (this.m_dv.Count > 0)
        dataRow = this.m_dv[0].Row;
      this.m_dv.RowFilter = "";
      return dataRow;
    }

    public ArrayList SelectFiltered(string filter) => new ArrayList()
    {
      (object) this.Select(filter)
    };

    public ArrayList SelectAll()
    {
      ArrayList arrayList = new ArrayList();
      foreach (object obj in this.m_dv)
        arrayList.Add(obj);
      return arrayList;
    }

    public ArrayList GetKeys()
    {
      this.m_dv = this.m_ds.Tables[0].DefaultView;
      ArrayList arrayList = new ArrayList();
      foreach (DataRow row in (InternalDataCollectionBase) this.m_ds.Tables[0].Rows)
        arrayList.Add(row["faction"]);
      return arrayList;
    }

    public void ValidationCallBack(object sender, ValidationEventArgs args) => this.Status = XMLStanding.State.INVALID;

    public enum State
    {
      VALIDATING,
      VALID,
      INVALID,
    }
  }
}
