using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace EVE_Mission_Counter.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  public class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) EVE_Mission_Counter.Properties.Resources.resourceMan, (object) null))
          EVE_Mission_Counter.Properties.Resources.resourceMan = new ResourceManager("EVE_Mission_Counter.Properties.Resources", typeof (EVE_Mission_Counter.Properties.Resources).Assembly);
        return EVE_Mission_Counter.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get => EVE_Mission_Counter.Properties.Resources.resourceCulture;
      set => EVE_Mission_Counter.Properties.Resources.resourceCulture = value;
    }
  }
}
