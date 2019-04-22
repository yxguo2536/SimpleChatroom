<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="SimpleChatroom.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>簡易聊天室</title>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>-->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    </style>
</head>
<body>
    <br />
    <br />
    <br />
    <form id="form1" runat="server" class="form-horizontal">
    <div class="row text-center vertical-middle-sm">

        <div class="form-group">
			<label class="control-label col-sm-4">帳號:</label> <!-- Label沒什麼特殊顯示效果，不過當你點"帳號:"文字，效用等同於點「輸入框」，然後你就可以打字了 -->
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
			</div>
		</div>
		<div class="form-group">
			<label class="control-label col-sm-4">密碼:</label>
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox2" runat="server" class="form-control" type="password"></asp:TextBox>
			</div>
		</div>
        <div class="form-group"> 
			<div class="col-sm-offset-2 col-sm-8">
                <asp:Button ID="ButtonLogIn" runat="server" Text="登入" class="btn btn-default" OnClick="ButtonLogIn_Click"/>
                <asp:Button ID="ButtonRegister" runat="server" Text="註冊" class="btn btn-default" OnClick="ButtonRegister_Click"/>
			</div>
		</div>

    </div>
    </form>
</body>
</html>
