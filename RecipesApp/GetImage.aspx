<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageVerifyService.ServiceClient imgService = new ImageVerifyService.ServiceClient("BasicHttpsBinding_IService");

        string myStr = (string)Session["generatedString"];

        Stream myStream = imgService.GetImage(myStr);
        byte[] buffer = new byte[myStream.Length];
        myStream.Read(buffer, 0, (int)myStream.Length);
        myStream.Close();
        Stream imageStream = (Stream)Session["imageStream"];
        byte[] imageData;

        // Check if the session contains image data
        if (myStream != null)
        {
            // Read the image data into a byte array
            imageData = new byte[myStream.Length];
            myStream.Read(imageData, 0, imageData.Length);

            // Clear the response and set content type to image
            Response.Clear();
            Response.ContentType = "image/png";

            // Write the image data to the response stream
            Response.BinaryWrite(imageData);
        }
    }
</script>
