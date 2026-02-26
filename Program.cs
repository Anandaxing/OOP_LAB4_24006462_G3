using System;

class Book
{
  private string bookTitle = "";
  private int bookID;

  private bool availability;

  public Book(string bookTitle, int bookID)
  {
    this.bookTitle = bookTitle;
    this.bookID = bookID;
    availability = true;
  }

  public bool checkBookAvailability()
  {
    if(availability) return true;
    return false;
  }

  public void ownBook(int memberID)
  {
    availability = false;
    Console.WriteLine($"BookID: {bookID} has been successfully borrowed by ID: {memberID}!");
  }

  public void returnBook(int memberID)
  {
    availability = true;
    Console.WriteLine($"BookID: {bookID} has been successfully returned by ID: {memberID}!");
  }

}

class Member
{
  private string memberName = "";
  private int memberID;

  public Member(string memberName, int memberID)
  {
    this.memberName = memberName;
    this.memberID = memberID;
  }

  public void MemberBorrowBook(Book borrowedBook)
  {
    if(borrowedBook.checkBookAvailability()) borrowedBook.ownBook(memberID);
    else Console.WriteLine($"Book is not available!");
  }

  public void MemberReturnBook(Book borrowedBook)
  {
    if(!borrowedBook.checkBookAvailability()) borrowedBook.returnBook(memberID);
    else Console.WriteLine("Book is not being borrowed!");
  }
}

class Library
{
  public static void Main()
  {
    Book book1 = new Book("Python Programming", 250001);
    Book book2 = new Book("C# Programming", 250002);
    Member member1 = new Member("", 210001);
    Member member2 = new Member("", 210002);
    member1.MemberBorrowBook(book1);
    member2.MemberBorrowBook(book1);
    member2.MemberBorrowBook(book2);
    member1.MemberReturnBook(book1);
  }
}