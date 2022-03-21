//@CodeCopy
//MdStart

namespace QTCityCongestionCharge.Logic
{
    public interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
