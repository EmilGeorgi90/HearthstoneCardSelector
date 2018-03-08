class Deck {
    constructor() {
        this.cards = [];
    }
}

var deckHandler = {
    set addCard(div) {
        this.deck.appendChild(div);
    },
    get allCards() {
        var d = new Deck();
        this.deck.childNodes.forEach(
            function (t = this) {
                if (t != null) {
                    d.cards.push(t);
                }
            }
        );
        return d;
    },
    deck: []
}
var card = [];
var counter = 0;
deckHandler.deck = document.getElementById("cardHolder");
function cardClassHanldere(age) {
    counter = 0;
    var someting;
    var divs = Array.from(document.querySelectorAll("#cardHolder > .cards"), element => element.className.split(" ", 1)[0])
    if (age.className != undefined) {
        card = divs;
        var tempcard = []
        for (someting of card) {
            tempcard.push(someting)
        }
        for (var currcard of tempcard) {
            if (currcard == age.className.split(" ", 1)[0]) {
                counter++
                if (counter >= 2) {
                    return false;
                }
            }
        }
    }
    return true;
};
function AddCard(inp) {
    if ($(inp).parent("#cardHolder").hasClass("cardHolder")) {
        inp.remove();

    } else {
        ages = deckHandler.allCards.cards;
        if (cardClassHanldere(inp) == true) {
            deckHandler.deck = document.getElementById("cardHolder");
            deckHandler.addCard = inp.cloneNode(true);
            ages = deckHandler.allCards.cards
        }
        else {
            alert("you can only have 2 of each card in your deck")
        }
    }
}



