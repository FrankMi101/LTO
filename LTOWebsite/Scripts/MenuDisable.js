function Open3TextCompairPage(_myMenuListID) {
    try {
        var _Result = window.showModalDialog("../CommonPages/BaseContextCompair.aspx", window, "scroll:no;resizable:yes;help:no;status:no;dialogTop:100;dialogLeft:50;dialogHeight:550px;dialogWidth:750px");
        if (_Result != null) {
            if (_Result == "Failed") {
                SaveDataCompletedEnableMenu2(_Result, _myMenuListID)
            }
            if (_Result == "Successfully") {
                var myTextChange = document.getElementById("txtContextChange");
                myTextChange.value = "0";
                SaveDataCompletedEnableMenu2(_Result, _myMenuListID)
            }
            if (_Result == "Cancel") {
                window.alert("Update has been cancel by user!");
                var myTextChange = document.getElementById("txtContextChange");
                myTextChange.value = "0";
                LeftMenuEnable(_myMenuListID, true);
            }
        }
    }
    catch (e) {  window.alert("Your browser does not support the Functions !")}
}
 
function SaveDataCompletedEnableMenu2(_Result, _myMenuListID) {

    if (_Result == "Successfully") {
        window.alert("Saved successfully!");
        LeftMenuEnable(_myMenuListID, true);   // EnableLeftMenuandTab(_myMenuListID);
    }
    else {
        window.alert("Saved failed!");
    }
}
function LeftMenuEnable(_myMenuListID, myVal) {
 
    try {
       // var listbar = parent.document.getElementById(_myMenuListID);
       // listbar.disabled != myVal;
    }
    catch (e) { }
    try {
        var PrevB = document.getElementById("btnPrev");
        var NextB = document.getElementById("btnNext");
        PrevB.disabled != myVal;
        NextB.disabled != myVal;
    }
    catch (e) { }

    try {
        parent.document.Script.PopUpDIV1();  // for IE
    }
    catch (e) {
        try {
            window.opener.PopUpDIV1();  // for FireFax
        }
        catch (e) {
            try {
                parent.PopUpDIV1(); // for Google Chrome
            }
            catch (e)
            { window.alert("Your Browser does not support iFrame Call !") }
        }
    }
}


function closeMeCheckSave() {
    try {
         var myiFrame = document.getElementById("main");
        var myTextChange = myiFrame.contentDocument.getElementById("txtContextChange");
         if (myTextChange.value == "1") {
            var mySave = myiFrame.contentDocument.getElementById("SaveB");
             mySave.click();
             myTextChange.value == "0";
             window.alert("Saved successfully! !")
             window.close();
         }
        else
        { window.close(); }

    }
    catch (e) { }

}
function changeDDLCheckSave() {
    try {
        var myiFrame = document.getElementById("main");
        var myTextChange = myiFrame.contentDocument.getElementById("txtContextChange");
        if (myTextChange.value == "1") {
            var mySave = myiFrame.contentDocument.getElementById("SaveB");
            mySave.click();
            myTextChange.value == "0";
        }
        else
        { }

    }
    catch (e) { }

}
function FeedBack(pCode, pTitle) {
    window.showModalDialog('../CommonPages/BaseFeedBack.aspx?pCode=' + pCode + "&pTitle=" + pTitle, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:80px;dialogLeft:100px;dialogHeight:550px;dialogWidth:750px");

}


function Panel() {// debugger
    var myMenu = document.getElementById("iepmenutree")
    var myimg = document.getElementById("panelimg")
    if (_StatePanel == "open") {
        myMenu.style.width = "0px";
        myimg.src = "../images/openMenu.bmp";
        myimg.title = "Show the Menu";
        _StatePanel = "close";
    }
    else {
        myMenu.style.width = "182px";
        myimg.src = "../images/closeMenu.bmp";
        myimg.title = "Hide the Menu";
        _StatePanel = "open";

    }
}
function PanelChange(_op) {
    var myimg = document.getElementById("panelimg")
    if (_op == "over") {
        if (_StatePanel == "open")
            myimg.src = "../images/closeMenu_over.bmp";
        else
            myimg.src = "../images/openMenu_over.bmp";
    }
    else {
        if (_StatePanel == "open")
            myimg.src = "../images/closeMenu.bmp";
        else
            myimg.src = "../images/openMenu.bmp";
    }
}


function SetIEMenus() {
    window.status = "no";
    window.toolbars = "no";

}


/*
function DisableMenu(idCtl) {
    var id = document.FormIEP99.elements[idCtl].value;
    var menu = igmenu_getMenuById('TopMenu1UltraWebMenu2');
    var itemID = 'TopMenu1UltraWebMenu2' + '_' + id;
    var item = igmenu_getItemById(itemID);
    item.setEnabled(false);
    window.status = item.getText();
    return false;
}

 
function DisableMenu2(idCtl, lCtrol) {
    var id = document.FormIEP99.elements[idCtl].value;
    var menu = igmenu_getMenuById('TopMenu1UltraWebMenu2');
    var itemID = 'TopMenu1UltraWebMenu2' + '_' + id;
    var item = igmenu_getItemById(itemID);
    item.setEnabled(false);
    window.status = item.getText();

    // UltraWebTab1__ctl2__ctl0_rblCompetency_0.Enabled =false
    //  UltraWebTab1__ctl2__ctl0_rblCompetency_1.Enabled =false
    //  UltraWebTab1:_ctl2:_ctl0:rblCompetency.Enabled =false
    lCtrol.Enabled = false;
    return false;
}




function setMenuTreeNodeFucus1(_node, _action, _treeID) {
    try {  //  debugger 
        //  parent.document.Script.setMenuTree(_node,_action,_treeID) ;  
        //   var treeNode = "/WebSite/ExperiencedTeacher/" + _node 
        var tree = parent.igtree_getTreeById(_treeID);
        var node = tree.getSelectedNode();
        //  node.hasChildren
        // node.getFirstChild
        // node.getTargetUrl
        //   node.getParent
        if (_action == "Next") {
            if (node != null) {
                var node1 = node
                node = node.getNextSibling();
                while (node != null && !node.getEnabled())
                    node = node.getNextSibling();
                if (node != null) {
                    if (node.hasChildren()) {
                        node = node.getFirstChild();
                        node.setSelected(true);
                    }
                    else
                        node.setSelected(true);
                }
                else {
                    node = node1.getParent();
                    node = node.getNextSibling();
                    node.setSelected(true);
                }
            }
        }
        else {
            if (node != null) {
                node1 = node
                node = node.getPrevSibling();
                while (node != null && !node.getEnabled())
                //  if (node.getTargetUrl() != treeNode)
                    node = node.getPrevSibling();
                if (node != null)
                    node.setSelected(true);
                else {
                    node = node1.getParent();
                    node = node.getPrevSibling();
                    node.setSelected(true);
                }
            }
        }
    }

    catch (e)
    { }
}


 
function setMenuTreeNodeFucus(_cnode, _node, _action, _treeID) {
    try {  // debugger
        //  parent.document.Script.setMenuTree(_node,_action,_treeID) ;  

        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        var node = tree.getSelectedNode();
        for (var i = 0; i < 14; i++) {
            var nodeID = treeNode[i];
            var nodeTag = nodeID.getTag();
            if (nodeTag == _cnode) {
                var _changeValue = document.getElementById("txtContextChange").value
                if (_changeValue == "1") {
                    try {
                        var _image = "./images/el_done1.bmp"; //  //"~\images\el_done1.bmp";
                        var _image1 = nodeID.element.children[1].src;

                        nodeID.element.children[1].src = _image1.replace("el_black.bmp", "el_done1.bmp");
                        if (nodeID.element.children[1].nameProp != "el_done1.bmp")
                            nodeID.element.children[1].src = _image1.replace("el_enter1.bmp", "el_done1.bmp");
                        // nodeID.element.children[1].nameProp = _image ;
                    }
                    catch (e)
                              { }
                }

            }
            if (nodeTag == _node) {
                if (nodeID.getEnabled()) {
                    nodeID.setSelected(true);
                    break;
                }
                else {
                    if (_action == "Next") {
                        nodeID = treeNode[i + 1];
                        if (nodeID.getEnabled()) {
                            nodeID.setSelected(true);
                            break;
                        }
                        else {
                            nodeID = treeNode[i + 2];
                            nodeID.setSelected(true);
                            break;
                        }
                    }
                    else {
                        nodeID = treeNode[i - 1];
                        if (nodeID.getEnabled()) {
                            nodeID.setSelected(true);
                            break;
                        }
                        else {
                            nodeID = treeNode[i - 2];
                            nodeID.setSelected(true);
                            break;
                        }

                    }
                }
            }

        }
    }
    catch (e)
      { }
}

function setMenuTreeNodeFucusPageLoad(_node, _treeID) {
    try { // debugger
        //  parent.document.Script.setMenuTree(_node,_action,_treeID) ;  

        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        for (var i = 0; i < 12; i++) {
            var nodeID = treeNode[i];
            var nodeTag = nodeID.getTag();
            if (nodeTag == _node) {
                if (nodeID.getEnabled()) {
                    nodeID.setSelected(true);
                    break;
                }

            }

        }
    }
    catch (e)
      { }
}

function checkMenuEnable(_treeID, _rbl) {
    try {  //debugger
        checkImprovementPlanMenu(_rbl);
        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        //  var myRblist = document.getElementById(_rbl); 
        var nodeID = treeNode[13];
        var _image1 = nodeID.element.children[1].src;
        try {
            if (_rbl == "rblOverallRating_0") {
                nodeID.setEnabled(true);
                var _Cloor = nodeID.element.children[3].currentStyle.color;
                nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");
                //nodeID.element.children[3].Style.color ="black";
            }
            else {
                nodeID.setEnabled(false)
                nodeID.element.children[1].src = _image1.replace("el_black.bmp", "el_run2.bmp");
                if (nodeID.element.children[1].nameProp != "el_run2.bmp")
                    nodeID.element.children[1].src = _image1.replace("el_done1.bmp", "el_run2.bmp");
                // nodeID.element.children[3].Style.color ="darkgray";
            }
        }
        catch (e)
            { }

        var nodeID = treeNode[16];
        nodeID.setEnabled(true);
        var _image1 = nodeID.element.children[1].src;
        nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");
        // nodeID.element.children[3].currentStyle.color ="black" ;


    }
    catch (e)
    { }

}
function checkMenuEnableNT(_treeID, _rbl) {
    try {  // debugger
        checkEnrichmentPlanMenu(_rbl);
        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        //  var myRblist = document.getElementById(_rbl); 
        var nodeID = treeNode[11];
        nodeID.setEnabled(true);
        var _image1 = nodeID.element.children[1].src;
        nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");

        var nodeID = treeNode[13];
        nodeID.setEnabled(true);
        var _image1 = nodeID.element.children[1].src;
        nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");
        // nodeID.element.children[3].currentStyle.color ="black" ;


    }
    catch (e)
    { }

}

function setMenuTreeNodeImage(_node, _image, _treeID) {
    try {  //  debugger
        //  parent.document.Script.setMenuTree(_node,_action,_treeID) ;  
        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        var node = tree.getSelectedNode();
        for (var i = 0; i < 11; i++) {
            var nodeID = treeNode[i];
            var nodeTag = nodeID.getTag();
            if (nodeTag == _node) {
                nodeID.element.children[1].src = _image;
                break;
            }

        }
    }
    catch (e)
      { }
}

function setTreeMenuImages() {  //debugger
    window.alert("unload event");
}

function checkImprovementPlanMenu(_rbl) {
    try {
        try {
            var listB = parent.iglbar_getListbarById("UltraWebListbar1");
            if (_rbl == "rblOverallRating_1")
                listB.Groups[5].setEnabled(true);
            else
                listB.Groups[5].setEnabled(false);
        }
        catch (e)
          { }
        //   debugger 
        var _treeID = "UltraWebListbar1ctl05UltraWebTree6"
        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        for (var i = 0; i < 5; i++) {
            try {
                var nodeID = treeNode[i];
                var _image1 = nodeID.element.children[1].src;
                if (_rbl == "rblOverallRating_1") {
                    nodeID.setEnabled(true);
                    nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");
                    // nodeID.element.children[3].currentStyle.color = "black";
                }
                else {
                    nodeID.setEnabled(false)
                    nodeID.element.children[1].src = _image1.replace("el_black.bmp", "el_run2.bmp");
                    // nodeID.element.children[3].currentStyle.color = "darkgray";

                }

            }
            catch (e)
             { }
        }

    }
    catch (e)
    { }

}

function checkEnrichmentPlanMenu(_rbl) {
    try {
        var listB = parent.iglbar_getListbarById("UltraWebListbar1");
        if (_rbl == "rblOverallRating_1")  // Development need
        {
            listB.Groups[3].setEnabled(true); // Enrichment plan
            //  checkTreeEnable("UltraWebListbar1ctl03UltraWebTree3",true ) ;
        }
        else {
            listB.Groups[3].setEnabled(false);
            //  checkTreeEnable("UltraWebListbar1ctl03UltraWebTree3",false );
        }
        if (_rbl == "rblOverallRating_2")    // Unsatisfactory
        {
            listB.Groups[4].setEnabled(true); // improvement plan
            //  checkTreeEnable("UltraWebListbar1ctl04UltraWebTree4",true ) ;
        }
        else {
            listB.Groups[4].setEnabled(false);
            //   checkTreeEnable("UltraWebListbar1ctl04UltraWebTree4",false );
        }
    }
    catch (e)
    { }

}

function checkTreeEnable(_treeID, _eValue) {
    try {
        //var _treeID = "UltraWebListbar1ctl02UltraWebTree3"
        var tree = parent.igtree_getTreeById(_treeID);
        var treeNode = tree.getNodes(_treeID);
        for (var i = 0; i < 5; i++) {
            try {
                var nodeID = treeNode[i];
                var _image1 = nodeID.element.children[1].src;
                nodeID.setEnabled(_eValue);
                if (_eValue) //  ( _rbl == "rblOverallRating_1" )
                {
                    nodeID.element.children[1].src = _image1.replace("el_run2.bmp", "el_black.bmp");
                }
                else {
                    nodeID.element.children[1].src = _image1.replace("el_black.bmp", "el_run2.bmp");
                }
            }
            catch (e)
             { }
        }

    }
    catch (e)
    { }

}

*/ 