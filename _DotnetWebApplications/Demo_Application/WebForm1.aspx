<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Demo_Application.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LPU Registration Form</title>
</head>
<body>
    <form style="text-align:center; background-color:lightyellow" id="form1" runat="server">
        <div>
            <h1 style="text-align:center">LPU Registration Form</h1>
            <br />
            <br />
            <input id="Name" type="text" placeholder="Name" />
            <br />
            <br />
            <input id="Email" type="email" placeholder="Email" />
            <br />
            <br />
            <input id="Tel" type="tel" placeholder="Mobile Number" />
            <input id="Otp" type="number" placeholder="OTP" />
            <br />
            <br />
            <input id="State" type="text" placeholder="State" />
            <input id="City" type="text" placeholder="City" />
            <br />
            <br />
            <input id="Qualification" type="text" placeholder="Qualification" />
            <input id="Discipline" type="text" placeholder="Discipline Intrested In" />
            <br />
            <br />
            <input id="TermsAndConditions" type="checkbox" />
            <p>I authorize Lovely Professional University to contact me <br />with updates and notifications via Email, SMS,<br /> Whatsapp and Call. This will override the registry on<br /> DND / NDNC. *</p>

            <input id="Submit" type="submit" value="Apply Now" />
        </div>
    </form>
</body>
</html>
