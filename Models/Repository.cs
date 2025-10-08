namespace ITEquipmentBorrowApp.Models
{
    public static class Repository
    {
        private static List<ITEquipment> equipments = new List<ITEquipment>
        {
            new ITEquipment { Id = 1, Type = EquipmentType.Laptop, Description = "Dell XPS 13", IsAvailable = true },
            new ITEquipment { Id = 2, Type = EquipmentType.Tablet, Description = "iPad Pro", IsAvailable = false },
            new ITEquipment { Id = 3, Type = EquipmentType.Another, Description = "Epson EX3260", IsAvailable = true },
            new ITEquipment { Id = 4, Type = EquipmentType.Another, Description = "LG UltraFine 5K", IsAvailable = true },
            new ITEquipment { Id = 5, Type = EquipmentType.Phone, Description = "iPhone 12", IsAvailable = false }
        };
        private static List<ITEquipmentRequest> requests = new List<ITEquipmentRequest>();
        private static int nextId = 1;

        public static IEnumerable<ITEquipmentRequest> Requests => requests;
        public static IEnumerable<ITEquipment> Equipments => equipments;

        public static void AddRequest(ITEquipmentRequest request)
        {
            request.Id = nextId++;
            requests.Add(request);
        }

        public static IEnumerable<ITEquipmentRequest> GetRequests()
        {
            return requests;
        }
    
    }
} 

