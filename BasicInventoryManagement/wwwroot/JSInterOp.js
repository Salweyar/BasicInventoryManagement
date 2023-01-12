function PreventFormSubmition(formId) {

    document.getElementById(`${formId}`).addEventListener("keydown", function (event) {

        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }

    });
}


function PrintReport(printId) {
    $(document).ready(function () {
        var doc = new jsPDF();
        var myBlob;

        $(`#${printId.printId}`).click(function () {
            doc.fromHTML($(`#${printId.content}`).html(), 15, 15, {
                'width': 170                
            });
            
            myBlob = doc.save('blob');
           doc.arrayBufferToBase64(function (buffer) {
                var binary = '';
                var bytes = new Uint8Array(buffer);
                var len = bytes.byteLength;
                for (var i = 0; i < len; i++) {
                    binary += String.fromCharCode(bytes[i]);
               }
               console.log(binary);
            });
            console.log(doc);
        });
       
    });
    
}