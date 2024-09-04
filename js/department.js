/**
 * Created by WangHui on 2020/11/24.
 */

var user, role, currentID, flag = true;

function add() {
    openlayer()
    currentID = "";
}

function openlayer(id){
    layer.open({
        type: 2,
        title: '添加信息',
        shadeClose: true,
        shade: 0.5,
        skin: 'layui-layer-rim',
//            maxmin: true,
        closeBtn:2,
        area: ['80%', '90%'],
        shadeClose: true,
        closeBtn: 2,
        content: 'depart_tail.aspx'
        //iframe的url
    });
}





