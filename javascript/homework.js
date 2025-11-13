//1 

let salaries = {
John: 100,
Ann: 160,
Pete: 130
}

let sum = 0;
for (let key in salaries){
    sum += salaries[key];
}

console.log(sum);

//2. 

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] === 'number') {
            obj[key] *= 2;
        }
    }
}

multiplyNumeric(menu);
console.log(menu);

//3 
function checkEmailId(str) {
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.');
    
    if (atIndex === -1 || dotIndex === -1) {
        return false;
    }
    
    if (atIndex >= dotIndex) {
        return false;
    }
    
    if (dotIndex - atIndex <= 1) {
        return false;
    }
    
    return true;
}

//4 
function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength - 1) + "...";
    }
    return str;
}

let answer = truncate("What I'd like to tell on this topic is:", 20);
console.log(answer);

//5 
let array = ['James', 'Bernie'];
console.log(array);
array.push('Robert');
console.log(array);
array[Math.floor(array.length/2)] = 'Calvin';
console.log(array);
array.shift();
console.log(array);
array.unshift('Regal');
array.unshift('Rose');
console.log(array);