using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities;

public class VillaGallery : BaseEntity
{
    public long VillaId { get; set; }
    public required string FilePath { get; set; }

    public Villa Villa { get; set; }
}
