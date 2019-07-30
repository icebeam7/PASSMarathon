namespace PASSMarathon.Helpers
{
    public static class Constants
    {
        public static readonly string LocalEndpoint = "http://192.168.99.101:5000/";
        public static readonly string LocalService = "face/v1.0/detect";
        public static readonly string RequestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=gender%2Csmile%2Cglasses%2Cemotion&returnRecognitionModel=false";
    }
}
