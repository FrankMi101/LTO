

function MakeStaticHeader(gridId, height, width, headerHeight, isFooter, headerRow, headerView, mainContent) {
    var tbl = document.getElementById(gridId);
    if (tbl) {

        try {
            var DivHR = document.getElementById(headerRow);
            var DivHeader = document.getElementById(headerView);
            var DivMC = document.getElementById(mainContent);

            //var DivHR = document.getElementById('DivHeaderRow');   DivHeaderRow ,GridView2 ,DivMainContent
            //var DivHeader = document.getElementById('GridView2');
            //var DivMC = document.getElementById('DivMainContent');
            //   var DivFR = document.getElementById('DivFooterRow');

            //*** Set divMainContent Properties ****
            DivMC.style.width = '100%'; // width + 'px';
            DivMC.style.height = height + 'px';
            DivMC.style.position = 'relative';
            DivMC.style.top = -headerHeight + 'px';
            DivMC.style.zIndex = '1';

            //*** Set divheaderRow Properties ****
            DivHR.style.height = headerHeight + 'px';
            DivHR.style.width = '99%'; // DivMC.style.width - 16 + 'px'; // '99%';// (parseInt(width) - 16) + 'px';
            DivHR.style.position = 'relative';
            DivHR.style.top = '0px';
            DivHR.style.zIndex = '10';
            DivHR.style.verticalAlign = 'top';



            //****Copy Header in divHeaderRow****
            //   DivHR.appendChild(tbl.cloneNode(true));
            try {
                DivHeader.removeChild(1); // .deleteRow(1);
                DivHeader.removeChild(0);  //.deleteRow(0);
            }
            catch (e) { }
            DivHeader.appendChild(tbl.rows['0'].cloneNode(true));
            DivHeader.appendChild(tbl.rows['1'].cloneNode(true));

            // addGridViewHeader();

        } catch (e) {

        }

    }
}
function addGridViewHeader() {
    var index = 0
    //  var $myHeader = $("#GridView1").clone(true);


    $('#GridView1 > tbody  > tr:not(:first)').each(function () {
        var t1 = $(this).text();
        $(this).find('td').each(function (i, el) {
            var myHeaderStyle = this.style.cssText;
            //  window.alert(myHeaderStyle);
        });
        return false;
    })




}

function OnScrollDiv(Scrollablediv) {
    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
    //   document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
}

