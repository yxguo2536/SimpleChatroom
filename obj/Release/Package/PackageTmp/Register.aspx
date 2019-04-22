<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SimpleChatroom.Register" %>

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
			<label class="control-label col-sm-4">帳號:</label>
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="輸入註冊帳號"></asp:TextBox>
			</div>
		</div>
        <br />
		<div class="form-group">
			<label class="control-label col-sm-4">密碼:</label>
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox2" runat="server" class="form-control" type="password" placeholder="輸入註冊密碼"></asp:TextBox>
			</div>
		</div>
        <br />
        <div class="form-group">
			<label class="control-label col-sm-4">用戶名稱:</label>
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="輸入用戶名稱"></asp:TextBox>
			</div>
		</div>
        <br />
        <div class="form-group">
			<label class="control-label col-sm-4">E-mail:</label>
			<div class="col-sm-4">
                <asp:TextBox ID="TextBox4" runat="server" class="form-control" type="email" placeholder="輸入E-mail (假的也可以)"></asp:TextBox>
			</div>
		</div>
        <br />
        <div class="form-group">
            <label class="control-label col-sm-4">性別:</label>
            <div class ="col-sm-1">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="男" GroupName ="gender"/>
            </div>
            <div class ="col-sm-1">
                <asp:RadioButton ID="RadioButton2" runat="server" Text="女" GroupName="gender"/>
            </div>
        </div>
        <br />
        <div class="form-group"> 
			<div class="col-sm-offset-3 col-sm-8">
                <asp:Button ID="Button1" runat="server" Text="註冊" class="btn btn-primary" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="取消" class="btn btn-default" OnClick="Button2_Click" />
			</div>
		</div>

    </div>
    </form>
</body>
</html>
