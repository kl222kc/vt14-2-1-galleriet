﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    
    <asp:Panel ID="UploadSuccess" runat="server" Text="Upladdningen lyckades!" Visible="false">
        <p id="success">Upladdningen lyckades!</p>
    </asp:Panel>

        <div id="cointaner">
        <form id="form1" runat="server">

    <div id="header">
         <h1>Galleriet</h1>
    </div>
    
    <div id="gallery">
    <asp:Image ID="ImagePlaceholder" CssClass="bigimg" runat="server" Visible="false"/>
    </div>

    <div id="thumbnails">
        <div id="innerwrap">
            <asp:Repeater ID="RepeaterImages" runat="server" SelectMethod="GetImages">
           <ItemTemplate>
               <asp:HyperLink ID="HyperLink" CssClass="thumb" NavigateUrl='<%# string.Format("?img={0}", Container.DataItem) %>' runat="server" ImageUrl='<%# string.Format("~/Content/Images/Thumbnails/{0}", Container.DataItem) %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>

    <div id="upload">
        <asp:ValidationSummary ID="ValidationSummary1" CssClass="error" HeaderText="Fel inträffade. Åtgärda felen och försök igen." runat="server" DisplayMode="BulletList" />
        <asp:FileUpload ID="FileUpload" CssClass="button" runat="server" />
        <asp:Button ID="UploadButton" runat="server" CssClass="button" Text="Ladda upp" OnClick="UploadButton_Click" />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" Display="None" CssClass="error" runat="server" ErrorMessage="En fil måste väljas." ControlToValidate="FileUpload" Text=""></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" Display="None" CssClass="error" runat="server" ErrorMessage="Filen måste vara av typen gif,jpg eller png." ControlToValidate="FileUpload" Text="" ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$"></asp:RegularExpressionValidator>
     </div>
        
    </form>
     </div>
    <script src="Scripts/jquery-1.11.0.min.js"></script>
    <script src="Scripts/Gallery.js"></script>
</body>
</html>
