// Magic Number (don't go too low):
var blockSize = 100;

/* Reactive CSS Transitions © Yogev Ahuvia
 * =======================================
 * These simple CSS blocks are alive. Each
 * block reacts to its neighbors by
 * transforming border-radius and color.
 * Endless block formations, endless
 * reactions between them.
 * ---------------------------------------
 * Works best on Google Chrome.
 */

var elements = [];
var x, y, index, isEvenRow;
var $container, $window;

function init() {
    $container = $('#bg');
    $window = $(window);
    x = (blockSize * 0.25);
    y = -(blockSize * 0.5);
    index = 0;
    isEvenRow = false;
}

$(document).ready(function () {
    init();
    build();
});

$(window).resize(function () {
    init();
    build();
    onCheck();
});

function build() {
    do {
        updateRowFlag();

        if (!elements[index]) {
            createNewBlock(x, y, index);
        } else {
            var elemObj = elements[index];
            $(elemObj.input).css({ 'left': x + 'px', 'top': y + 'px' });
            $(elemObj.block).css({ 'left': x + 'px', 'top': y + 'px' });
        }

        updateCoords();
        index++;
    } while (y <= $window.height() + blockSize);
}

function createNewBlock(x, y, index) {
    var style = ' style="width: ' + blockSize + 'px; height: ' + blockSize + 'px; left: ' + x + 'px; top: ' + y + 'px;"';
    var $input = $('<input class="inputblock" type="checkbox"' + style + '></input>');
    var $block = $('<div class="block"' + style + '></div>');

    $input.on('click', onCheck);

    elements.push({ input: $input[0], block: $block[0] });
    $container.append($input, $block);
}

function updateRowFlag() {
    if (x > $window.width()) {
        isEvenRow = !isEvenRow;
        x = (isEvenRow ? -(blockSize * 0.5) : (blockSize * 0.25));
        y += (blockSize * 0.75);
    }
}

function updateCoords() {
    x += blockSize + (blockSize * 0.5);
}

function getNeighbours(index, elem) {
    var neighbors = { Ne: undefined, NEe: undefined, Ee: undefined, SEe: undefined, Se: undefined, SWe: undefined, We: undefined, NWe: undefined };

    var Nc = {
        x: elem.offsetLeft + (elem.offsetWidth / 2),
        y: elem.offsetTop - elem.offsetHeight
    };

    var NEc = {
        x: elem.offsetLeft + elem.offsetWidth,
        y: elem.offsetTop - (elem.offsetHeight / 2)
    };

    var SEc = {
        x: elem.offsetLeft + elem.offsetWidth,
        y: elem.offsetTop + elem.offsetHeight
    };

    var Sc = {
        x: elem.offsetLeft + (elem.offsetWidth / 2),
        y: elem.offsetTop + (elem.offsetHeight * 2)
    };

    var SWc = {
        x: elem.offsetLeft,
        y: elem.offsetTop + elem.offsetHeight
    };

    var NWc = {
        x: elem.offsetLeft,
        y: elem.offsetTop - (elem.offsetHeight / 2)
    };

    for (var i = 0; i < elements.length; i++) {
        var cur = elements[i].input;

        if (isCoordOnElement(Nc.x, Nc.y, cur)) {
            neighbors.Ne = cur;
        }
        else if (isCoordOnElement(NEc.x, NEc.y, cur)) {
            neighbors.NEe = cur;
        }
        else if (isCoordOnElement(SEc.x, SEc.y, cur)) {
            neighbors.SEe = cur;
        }
        else if (isCoordOnElement(Sc.x, Sc.y, cur)) {
            neighbors.Se = cur;
        }
        else if (isCoordOnElement(SWc.x, SWc.y, cur)) {
            neighbors.SWe = cur;
        }
        else if (isCoordOnElement(NWc.x, NWc.y, cur)) {
            neighbors.NWe = cur;
        }
    }

    if (elements[index - 1])
        neighbors.We = elements[index - 1].input;
    if (elements[index + 1])
        neighbors.Ee = elements[index + 1].input;

    return neighbors;
}

function isCoordOnElement(x, y, elem) {
    if (x > elem.offsetLeft &&
        x < (elem.offsetLeft + elem.offsetWidth) &&
        y > elem.offsetTop &&
        y < (elem.offsetTop + elem.offsetHeight)) {
        return true;
    }

    return false;
}

function clearEffects($elem) {
    $elem.removeClass('Ns NWs NEs NWNEs Es SEs NESEs Ss SWs SESWs Ws NWs NWSWs NSs WEs');
}

function onCheck(e) {
    for (var i = 0; i < elements.length; i++) {
        var elemObj = elements[i];
        var neighbors = getNeighbours(i, elemObj.input);
        var $block = $(elemObj.block);
        clearEffects($block);

        if (neighbors.Ne && neighbors.Ne.checked)
            $block.addClass('Ns');
        if (neighbors.NEe && neighbors.NEe.checked)
            $block.addClass('NEs');
        if (neighbors.Ee && neighbors.Ee.checked)
            $block.addClass('Es');
        if (neighbors.SEe && neighbors.SEe.checked)
            $block.addClass('SEs');
        if (neighbors.Se && neighbors.Se.checked)
            $block.addClass('Ss');
        if (neighbors.SWe && neighbors.SWe.checked)
            $block.addClass('SWs');
        if (neighbors.We && neighbors.We.checked)
            $block.addClass('Ws');
        if (neighbors.NWe && neighbors.NWe.checked)
            $block.addClass('NWs');
    }
}