﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OAnew.Login" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"> 

<title>登录</title>
<link href="css/login.css" type="text/css" rel="stylesheet"> 
</head> 
<body> 
<div class="div_top">OA考勤办公管理系统</div>
<div class="login">
    <div class="message">用户登录</div>
    <div id="darkbannerwrap"></div>
    
    <form method="post" runat="server">
		<input name="action" value="login" type="hidden">
		<input name="username" placeholder="用户名" required="" type="text" id="user">
		<hr class="hr15">
		<input name="password" placeholder="密码" required="" type="password" id="pass">
		<hr class="hr15">
	
         <asp:Button ID="login_btn"  runat="server" Text="登录" OnClick="Button1_Click"  />
		<hr class="hr20">
		  <a onClick="alert('请联系管理员')">忘记密码</a>
	</form>

	
</div>


<script type="text/javascript" src="js/jquery.js"></script>
<script >
	$(function(){
		$("#login_btn").click(function(){

			var selectuser = $("#user").val();
			var pword = $("#pass").val();

			if (selectuser == "" || selectuser.length <= 1) {
				alert("用户名不能为空");
				$("#user").focus();
				return false;
			}
			if (pword == "" || pword.length < 1) {
				alert("密码不能为空");
				$("#pass").focus();
				return false;
			}
			


		});

		
	});

</script>
</body>
</html>
