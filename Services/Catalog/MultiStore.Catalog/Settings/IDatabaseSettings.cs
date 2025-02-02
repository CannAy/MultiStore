namespace MultiStore.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        //MongoDB Database ayarlari yapacagimiz alan/interface
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
