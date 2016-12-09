;
function Animal(name) {
    this.name = name;
    this.showName = function () {
        document.write(this.name);
        document.write('<br />');
    }
};

function Cat(name) {
    //构造继承
    Animal.call(this, name);
};

//原型链继承
Cat.prototype = new Animal();
//Cat.prototype = Animal.prototype;


var cat = new Cat("Black Cat");  
cat.showName();

if (cat instanceof Animal) {
    document.write('cat is Animal\'s instance.');
}
else {
    document.write('cat isn\'t Animal\'s instance.');
}

document.write('<br />');

if (cat instanceof Cat) {
    document.write('cat is Cat\'s instance.');
}
else {
    document.write('cat isn\'t Cat\'s instance.');
}