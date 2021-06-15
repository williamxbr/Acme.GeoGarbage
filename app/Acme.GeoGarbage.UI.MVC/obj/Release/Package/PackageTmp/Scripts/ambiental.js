const $TEMPO_VERIFICACAO = 10000;

function pegarCorHorario(valor) {
    switch (valor) {
        case 1:
            return "grey";
            break;
        case 2:
            return "green";
            break;
        case 3:
            return "yellow";
            break;
        case 4:
            return "red";
            break;
        case 5:
            return "orange";
            break;
        case 6:
            return "black";
            break;
    }
}

function pegarCorPing(valor) {
    switch (valor) {
        case 1:
            return "green";
            break;
        case 2:
            return "yellow";
            break;
        case 3:
            return "red";
            break;
        case 4:
            return "grey";
            break;
    }
}

var setorBar = {
    element: null,
    source: null,
    draw: function () {
        var numberElements = this.source.length;
        var sizeBox = 100 / numberElements;

        for (var i = 0; i < numberElements; i++) {

            var color = null;

            switch (this.source[i].StatusDePassagem) {
                case 1:
                    color = "grey";
                    break;
                case 2:
                    color = "black";
                    break;
                case 3:
                    color = "yellow";
                    break;
                case 4:
                    color = "green";
                    break;
            }

            var box = $("<div/>");
            box.css("width", sizeBox + "%");
            box.css("height", $(this.element).height());
            box.css("background", color);
            box.css("float", "left");
            box.id = "box-" + i;

            $(this.element).append(box);
        }
    }
}


var geometricForms = {
    drawCircle: function (color) {

        var circle = $("<div/>");
        circle.addClass("setor-line-circle");
        circle.css("background", color);
        return circle;
    },
    drawRectangle: function (color) {

        var rectangle = $("<div/>");
        rectangle.addClass("setor-line-bar");
        rectangle.css("background", color);
        return rectangle;
    }
}

var sectorLine = {
    element: null,
    source: null,
    draw: function () {

        var element = $(this.element);
        var size = this.source.length;
        var color = "";

        for (var i = 0; i < size; i++) {

            var item = this.source[i];

            switch (item.StatusDePassagem) {
                case 1:
                    color = "grey";
                    break;
                case 2:
                    color = "black";
                    break;
                case 3:
                    color = "yellow";
                    break;
                case 4:
                    color = "green";
                    break;
            }

            var title = item.PontoDeColeta.Nome + " " +
                        item.PontoDeColeta.Horario;

            var c = geometricForms.drawCircle(color);
            c.attr("title", title);
            c.tooltip();
            element.append(c);

            if (i != size - 1) {
                var rectangle = geometricForms.drawRectangle(color);
                element.append(rectangle);
            }
        }
    }
};
