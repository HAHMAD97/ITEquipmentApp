namespace ITEquipmentBorrowApp.Models
{
    public static class Repository
    {
        private static List<ITEquipment> equipments = new List<ITEquipment>
        {
            new ITEquipment { EquipmentId = 1, Type = "Laptop", Description = "Dell XPS 13", Availability = true },
            new ITEquipment { EquipmentId = 2, Type = "Tablet", Description = "iPad Pro", Availability = false },
            new ITEquipment { EquipmentId = 3, Type = "Projector", Description = "Epson EX3260", Availability = true },
            new ITEquipment { EquipmentId = 4, Type = "Monitor", Description = "LG UltraFine 5K", Availability = true },
            new ITEquipment { EquipmentId = 5, Type = "Phone", Description = "iPhone 12", Availability = false }
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

