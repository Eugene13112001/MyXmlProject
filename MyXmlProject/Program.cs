
using MyXmlProject.Factories;
using MyXmlProject.Models;
using MyXmlProject.Reader;
using MyXmlProject.XMLModels;

ReaderXmlClass readerXmlClass = new ReaderXmlClass();
while (true)
{
    Console.WriteLine("Введите название файла для передачи в бд");
    XmlListOrders orders = readerXmlClass.Read(String.Format("files/{0}.xml", Console.ReadLine()));
    XmlModelsFactory modelsFactory = new ModelFactory();
    foreach (XmlOrder order in orders.orders)
    {
        User user = await modelsFactory.CreateUser(order.User);
        Order? ord = await modelsFactory.CreateOrder(user, order);
        if (ord is null)
        {
            Console.WriteLine("Заказ с таким номером уже существует");
            continue;
        }

        foreach (XmlProduct prod in order.Products)
        {
            Product pr = await modelsFactory.CreateProduct(prod);
            await modelsFactory.CreateSale(pr, ord, prod.Count, prod.Price);
        }

    }
    Console.WriteLine("Операция успешно проведена");
}