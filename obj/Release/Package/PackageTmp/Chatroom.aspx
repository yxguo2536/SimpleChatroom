<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chatroom.aspx.cs" Inherits="SimpleChatroom.Chatroom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>簡易聊天室</title>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div><!--上方選單-->
        <ul class="nav nav-tabs col-sm-11">
			<li class="active"><a data-toggle="tab" href="">聊天室</a></li>
			<!--<li ><a data-toggle="tab" href="Profile.aspx">個人資料修改</a></li>
			<li ><a data-toggle="tab" href="UserList.aspx">會員管理</a></li>-->
		</ul>
        <asp:Button ID="ButtonLogOut" runat="server" Text="登出" class="btn btn-default btn-sm" OnClick="ButtonLogOut_Click" UseSubmitBehavior="false"/> <!--使其按下Enter不登出-->
    </div>

    <!--聊天室-->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonSend"> <!--按下Enter可送出訊息-->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                <br />
                <asp:Label ID="ChatArea" runat="server"></asp:Label>
                <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="Timer1_Tick">
                </asp:Timer>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <hr />
    聊天內容：<asp:TextBox ID="TextBox1" runat="server" Width="800px" autocomplete="off"></asp:TextBox> <!--使其不會auto fill-->
    &nbsp;<asp:Button ID="ButtonSend" runat="server" Text="聊天" class="btn btn-primary" OnClick="ButtonSend_Click"/>
    </form>
</body>
</html>
