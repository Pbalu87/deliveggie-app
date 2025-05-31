
db = db.getSiblingDB('admin'); 
db.Products.drop();
for (let i = 1; i <= 10; i++) {
  db.Products.insertOne({
    Name: "Product " + i,
    EntryDate: new Date(),
    Price: 10 + (i * 1.5)
  });
}

db.PriceReductions.drop();
db.PriceReductions.insertMany([
  {  DayOfWeek: 1, Reduction: 5 },
  {  DayOfWeek: 2, Reduction: 7 },
  {  DayOfWeek: 3, Reduction: 20 },
  {  DayOfWeek: 4, Reduction: 0 },
  {  DayOfWeek: 5, Reduction: 0 },
  {  DayOfWeek: 6, Reduction: 25 },
  {  DayOfWeek: 7, Reduction: 30 }
]);
