using SimplExModel.NetworkData;

namespace SimplExModel
{
    public class Package
    {
        public PackageType PackageType { get; set; }
        public object Message { get; set; }
        public Package(PackageType packageType, object message)
        {
            PackageType = packageType;
            Message = message;
        }
    }
}
