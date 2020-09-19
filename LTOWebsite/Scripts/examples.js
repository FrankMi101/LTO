

// Object Json

let address = {
    street: '225 Bamburgh Cir.',
    city: 'Toronto',
    postCode: 'M1W 3X9'
};
// Factory Function

let address1 = createAddress('225 Bamburgh Cir.', 'Toronto', 'M1W 3X9');

function createAddress(street, city, postCode) {
    return {
        street,
        city,
        postCode
    };
}

// Constructor Function

let address2 = new Address('225 Bamburgh Cir.', 'Toronto', 'M1W 3X9');
function Address(street, city, postCode) {
    this.street = street;
    this.city = city;
    this.postCode = postCode;
}

let address3 = address1;

var value1 = areEqual(address1, address2); // return true
var value2 = areSame(address1, address2); // return false;
var value3 = areSame(address1, address3); // return true;

// object same

function areSame(address1, address2) {
    return address1 === address2;
}

// object Equal
function areEqual(address1, address2) {
    return address1.street === address2.street &&
        address1.city === address2.city &&
        address1.postCode === address2.postCode;
}

// find Max
const max = getMax([1, 2, 3, 4, 2, 1]);
console.log(max);
function getMax(array) {
    if (array.length === 0) return undefined;
    return array.reduce((a, b) => (a > b) ? a : b);

    //let max = array[0];
    //for (let i = 1; i < array.length; i++) {
    //    if (array[i] > max)
    //        max = array[i];
    //    return max;
    //}
}

// Moves filter sort

const movies = [
    { title: 'a', year: 2018, rating: 4.5 },
    { title: 'b', year: 2018, rating: 4.7 },
    { title: 'c', year: 2018, rating: 3 },
    { title: 'd', year: 2011, rating: 4.5 }
];
// All the movies in 2018 with rating > 4
// Sort them by their rating
// Descending order
// Pick their title

let titles = movies
    .filter(m => m.year === 2018 && m.rating >= 4)
    .sort((a, b) => a.rating - b.rating)
    .reverse()
    .map(m => m.title);

console.log(titles);


// getters & setters

const person = {
    fistName: "frank",
    lastName: "Mi",
    get fullName() {
        return `${person.fistName} ${person.lastName}`;
    },
    set fullName(value) {
        let fName = value.split(' ');
        this.fistName = fName[0];
        this.lastName = fName[1];
    }
};

person.fullName = "John Smith";

//getters & setters on object

function Circle(radius) {
    this.radius = radius;
    let defaultLocation = { x: 0, y: 0 };
    this.getDefLocation = function () {
        return defaultLocation;
    }
    this.draw = function () {
        console.log("deaw");
    };
    Object.defineProperties(this, 'defaultLocation', {
        get: function () { return defaultLocation; },
        set: function (value) { defaultLocation = value; }
    });

}

const circle = new Circle(10);
circle.defaultLocation = 1;
circle.draw();


// Inhritas from Prototype
function Shape() { }

Shape.prototype.duplicate = function () {
    console.log('duplicate');
}

function Circle1(radius) {
    this.radius = radius;
}
Circle1.prototype = Object.create(Shape.prototype);
Circle1.prototype.constructor = Circle1;
Circle1.prototype.draw = function () {

}