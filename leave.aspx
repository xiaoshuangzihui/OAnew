<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leave.aspx.cs" Inherits="OAnew.WebForm3" %>

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
        .tabe_bot input,.tabe_bot  select{width: 180px;height: 30px;border-radius: 6px;border: none;border: 1px #ccc solid;
            margin-left: 0;
            margin-right: 20px;
            margin-top: 0;
        }
        .tabe_btn{width: 60px;height: 30px;background-color: #68b86c;border: none;border-radius: 6px;color: #fff}
        .out{ background:url(../images/tjico_down.png) no-repeat left 9px;}
    </style>
    <title>请假数据</title>
</head>

<body runat="server">
     <form id="form1" runat="server"  >
         
         <div class="emal">
             
    
             <div class="email_con" runat="server" style="display: block">
                 <div class="title">
                     <h2>请假数据</h2>
                 </div>
                 <div class="query">
                     <div class="tabe_bot">
                         <div class="l_left">
                             <label>选择文件：</label>
                             </div>
                         <div class="l_left"><asp:FileUpload ID="FileUpload1" runat="server" /></div>
                         
                         <div class="l_left">
                         <asp:Button ID="Button1" runat="server" Text="转换" cssclass="tabe_btn " Width="60px" OnClick="Button1_Click"/>
                         </div>
                         <div class="l_left">
                         </div>
                         <div class="l_left">
                             </div>
                       
                        
                         <div class="clear"></div>
                     </div>
                 </div>
                 <div class="table-operate ue-clear">
                     
                 </div>
                 <div class="table-box" runat="server" >

            

          
        </div>
                 <div class="pagination ue-clear"></div>
             </div>
             
             
         </div>
     </form>
</body>
<script type="text/javascript" src="js/jquery.js"></script>

<script src="js/bootstrap.min.js"></script>
<script src="js/bootstrap-table.js"></script>
<script src="js/bootstrap-table-zh-CN.min.js"></script>
<script src="js/date/js/laydate.js"></script>


<script>
    $(function () {
        $('#table01').bootstrapTable({
            method: "get",
            striped: true,
            singleSelect: false,
            url: "json/datum.json",
            dataType: "json",
            pagination: true, //分页
            pageSize: 10,
            pageNumber: 1,
            search: false, //显示搜索框
            contentType: "application/x-www-form-urlencoded",
            queryParams: null,
            columns: [
                {
                    checkbox:"true",
                    field: 'ID',
                    align: 'center',
                    valign: 'middle'
                },
                {
                    title: '标示',
                    field: 'id',
                    align: 'center',
                    formatter: function (value, row) {
                        var e = '<a  href="#"><img src="images/topmail.png"/> </a> ';

                        return e;
                    }
                },
                {
                    title: "发件人",
                    field: 'class',
                    align: 'center',
                    valign: 'middle'
                },
                {
                    title: '主题',
                    field: 'sex',
                    align: 'center',
                    valign: 'middle'
                },
                {
                    title: '发送时间',
                    field: 'type',
                    align: 'center'
                }


            ]
        });
    });
</script>


<script>
    !function(){
        laydate.skin('molv');//切换皮肤，请查看skins下面皮肤库
        laydate({elem: '#demo'});//绑定元素
        laydate({elem: '#demo01'});//绑定元素
        laydate({elem: '#demo02'});//绑定元素
        laydate({elem: '#demo03'});//绑定元素
    }();
</script>
<script src="js/layer_v2.1/layer/layer.js"></script>

<script>

    $(function () {
        $(".email_ul li").each(function (index) {
            $(this).on("click",function () {
                $(".emal_right .email_con").eq(index).fadeIn().siblings("div").stop().hide();
                $(this).addClass("li_active");
                $(this).siblings().removeClass("li_active");

            })
        })
    })
</script>
</html>
