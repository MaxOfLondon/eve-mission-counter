namespace EVE_Mission_Counter
{
  public class Standing
  {
    private string m_faction;
    private int m_level1;
    private int m_level2;
    private int m_level3;
    private int m_level4;
    private int m_level5;

    public string Faction
    {
      get => this.m_faction;
      set => this.m_faction = value;
    }

    public int Level1
    {
      get => this.m_level1;
      set => this.m_level1 = value;
    }

    public int Level2
    {
      get => this.m_level2;
      set => this.m_level2 = value;
    }

    public int Level3
    {
      get => this.m_level3;
      set => this.m_level3 = value;
    }

    public int Level4
    {
      get => this.m_level4;
      set => this.m_level4 = value;
    }

    public int Level5
    {
      get => this.m_level5;
      set => this.m_level5 = value;
    }
  }
}
