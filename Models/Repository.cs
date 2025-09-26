namespace ITEquipmentBorrowApp.Models
{
    public static class Repository
    {
        private static List<ITEquipmentRequest> requests = new List<ITEquipmentRequest>();
        private static int nextId = 1;

        public static IEnumerable<ITEquipmentRequest> Requests => requests;

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

