<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="OAnew.Department" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">

    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="css/bootstrap-table.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/info-mgt.css" />
      <link rel="stylesheet" href="css/pagination.css" />

    <style>
        .layui-layer-title{background:url(images/righttitlebig.png) repeat-x;font-weight:bold;color:#46647e; border:1px solid #c1d3de;height: 33px;line-height: 33px;}
        .tabe_bot label{width: 70px;text-align: right;font-size: 14px;font-weight: 900;color: #46647e}
        .l_left{float: left;margin-left: 2px;}
        .tabe_bot input,.tabe_bot  select{width: 180px;height: 30px;border-radius: 6px;margin:0 20px 0 0;border: none;border: 1px #ccc solid}
        .tabe_btn{width: 60px;height: 30px;background-color: #68b86c;border: none;border-radius: 6px;color: #fff}
        .del { background:url(../images/delico.png) no-repeat left 9px; }
    </style>

    <script src="js/jquery.js"></script>
    <script>
        function change() {
            var height01 = $(window).height();
            $(".tree_left").css('height', height01 - 35+"px");
        }
    </script>
    <title>部门管理</title>
</head>

<body  runat="server">
    <form id="form2" runat="server"  >
<div class="title"><h2>部门管理</h2></div>

<div class="l_left" style="width: 100%">
<div class="query">
    <div class="tabe_bot">
        <div class="l_left"><label>部门名称：</label><input type="text" placeholder="请输入部门名称" id="user" runat="server"></div>
        <div class="l_left"></div>
        <asp:Button ID="Button1" runat="server" Text="查询" cssclass="tabe_btn " Width="60px" OnClick="Button1_Click"/>
        <div class="clear"></div>
    </div>
</div>
<div class="table-operate ue-clear">
     <a href="javascript:;" class="add" onclick="add()">添加</a>
    <asp:Button ID="btnDelete" runat="server" Text="     删除"  OnClick="btnDelete_Click"  CssClass="del" BorderStyle="None"/>
    
   
    
</div>
    
        <div class="table-box" runat="server" >

            

                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered " PageSize="20" AllowPaging="true"  
                    OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging ="GridView1_PageIndexChanging"   OnRowCreated="GridView1_OnRowCreated" AutoGenerateColumns="False" >
                    <Columns>
                      
						  <asp:TemplateField  HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1"  runat="server"  />
                            </ItemTemplate>

                           
                        </asp:TemplateField>
					
                        <asp:BoundField DataField="dept_id" HeaderText="部门编码" HeaderStyle-Font-Bold="true"  SortExpression="部门编码"  >         
                         </asp:BoundField>
                        
                     
                       
                        <asp:BoundField DataField="dept_OA" HeaderText="部门名称" HeaderStyle-Font-Bold="true" SortExpression="部门名称" >         
                         </asp:BoundField>
                          
                       
						    <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50"
                            DataNavigateUrlFields="id" DataNavigateUrlFormatString="dept_modify.aspx?id={0}"
                            Text="编辑">
                        
                        </asp:HyperLinkField>
                        
                      
                         
                     
                    </Columns>
                </asp:GridView>
          
                               
                  
          
        </div>
   
<div class="pagination ue-clear"></div>
</div>
    </form>
</body>
<script type="text/javascript" src="js/jquery.js"></script>

<script src="js/department.js"></script>

<script src="js/bootstrap.min.js"></script>
<script src="js/bootstrap-table.js"></script>
<script src="js/bootstrap-table-zh-CN.min.js"></script>
<script src="js/date/js/laydate.js"></script>


<script>
    !function(){
        laydate.skin('danlan');//切换皮肤，请查看skins下面皮肤库
        laydate({elem: '#demo'});
        laydate({elem: '#demo1'});//绑定元素
    }();
</script>

<script src="js/layer_v2.1/layer/layer.js"></script>
  

</html>