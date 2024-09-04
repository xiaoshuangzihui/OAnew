<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OAnew.index" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="utf-8">
<link rel="stylesheet" href="css/base.css" />
<link rel="stylesheet" type="text/css" href="css/jquery.dialog.css" />
<link rel="stylesheet" href="css/index.css" />
    <style>
        .layui-layer-title{background:url(images/righttitlebig.png) repeat-x;font-weight:bold;color:#46647e; border:1px solid #c1d3de;height: 33px;line-height: 33px;}
    </style>
<title>OA考勤办公管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
<div id="container">
	<div id="hd">
    	<div class="hd-wrap ue-clear">
        	<div class="top-light"></div>
            <h1 class="logo"></h1>
            <div class="login-info ue-clear">
                <div class=" ue-clear">
                  
                   <asp:Label ID="Label1" runat="server" Text="" Height="30px" Width="440px" ForeColor="White"></asp:Label>
                </div>
                
               
                
            </div>
            <div class="toolbar ue-clear">
                <a href="index.aspx" class="home-btn" >首页</a>
                
                <a href="javascript:void(0)" class="quit-btn exit home-btn">退出</a>
            </div>
        </div>
    </div>
    <div id="bd">
    	<div class="wrap ue-clear">
        	<div class="sidebar">
            	<h2 class="sidebar-header"><p>功能导航</p></h2>
                <ul class="nav">
                
                    <li class="land"><div class="nav-header"><a href="JavaScript:;" class="ue-clear" ><span>数据转换</span><i class="icon hasChild"></i></a></div>
                        <ul class="subnav">
                        
                            <li><a href="leave.aspx" target="right">请假数据</a></li>
                        
                            <li><a href="trip.aspx" target="right">出差数据</a></li>
                            <li><a href="inbusiness.aspx" target="right">市内因公出差</a></li>
                             <li><a href="add.aspx" target="right">补卡数据</a></li>
                             <li><a href="education.aspx" target="right">培训数据</a></li>

                        </ul>
                    </li>

             

                    <li class="part"><div class="nav-header"><a href="JavaScript:;" class="ue-clear" ><span>系统管理</span><i class="icon hasChild"></i></a></div>
                        <ul class="subnav">
                            <li><a href="#" onclick="return false;" target="right">用户管理</a></li>
                            <li><a href="Department.aspx" target="right">部门管理</a></li>

                            

                        </ul>
                    </li>
                </ul>
            </div>
            <div class="content">
            	<iframe src="leave.aspx" id="iframe" width="100%" height="100%" frameborder="0" name="right" style="min-width: 1100px"></iframe>
            </div>
        </div>
    </div>
    <div id="ft" class="foot_div">

            
            <em>中衡设计集团股份有限公司</em>

     
    </div>
</div>
<div class="exitDialog">
	<div class="dialog-content">
    	<div class="ui-dialog-icon"></div>
        <div class="ui-dialog-text">
        	<p class="dialog-content">你确定要退出系统？</p>
            <p class="tips">如果是请点击“确定”，否则点“取消”</p>
            
            <div class="buttons">
                <input type="button" class="button long2 ok" value="确定" />
                <input type="button" class="button long2 normal" value="取消" />
            </div>
        </div>
        
    </div>
</div>
    </form>
</body>
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/core.js"></script>
<script type="text/javascript" src="js/jquery.dialog.js"></script>
<script type="text/javascript" src="js/index.js"></script>
<script src="js/layer_v2.1/layer/layer.js"></script>

</html>
