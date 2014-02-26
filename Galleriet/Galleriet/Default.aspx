<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Galleriet</h1>

        <asp:Image ID="ImagePlaceholder" runat="server" Visible="false"/>

    <div>
        <asp:Repeater ID="RepeaterImages" runat="server" SelectMethod="GetImages">
           <ItemTemplate>
               <asp:HyperLink ID="HyperLink" runat="server" ImageUrl='<%# string.Format("~/Content/Images/Thumbnails/{0}", Container.DataItem) %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div>
        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="UploadButton" runat="server" Text="Button" OnClick="UploadButton_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error" runat="server" ErrorMessage="En fil måste väljas." ControlToValidate="FileUpload" Text="*"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="error" runat="server" ErrorMessage="Filen måste vara av typen gif,jpg eller png." ControlToValidate="FileUpload" Text="*" ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$"></asp:RegularExpressionValidator>
    </div>
        <asp:ValidationSummary ID="ValidationSummary1" CssClass="error" HeaderText="Fel inträffade. Åtgärda felen och försök igen." runat="server" />
    </form>
</body>
</html>
