using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Flower
{
    public string FlowerId { get; set; } = null!;

    public string FtypeId { get; set; } = null!;

    public string FcharacteristicId { get; set; } = null!;

    public string FcolorId { get; set; } = null!;

    public virtual FloralCharacteristic Fcharacteristic { get; set; } = null!;

    public virtual FloralColor Fcolor { get; set; } = null!;

    public virtual Material FlowerNavigation { get; set; } = null!;

    public virtual ICollection<FlowerSalesTargetHistory> FlowerSalesTargetHistories { get; set; } = new List<FlowerSalesTargetHistory>();

    public virtual FloralType Ftype { get; set; } = null!;
}
