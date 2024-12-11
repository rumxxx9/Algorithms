using System;
using static System.Console;

namespace CommunityLibrarySystem
{
    public class MemberCollection
    {
        public Member[] members;
        public Movie[] BorrowedMovies { get; }
        int count;

        public MemberCollection()
        {
            //set member[]
            members = new Member[1000];
            BorrowedMovies = new Movie[5];
            count = 0;
        }

        //Add member function
        public void AddMember(string firstName, string lastName, int password, int phoneNumber)
        {
            foreach (Member member in members) //members
            {
                if (member != null && member.FirstName == firstName) //unique first name
                {
                    WriteLine("This member is existed. Please try another name.");
                    return;
                }
            }
            Member newMember = new Member(firstName, lastName, password, phoneNumber); // add new member
            members[count++] = newMember;
        }

        //remove member method
        public void RemoveMember(string firstName, string lastName)
        {
            Member memberToRemove = null;
            foreach (Member member in members)
            {
                //remove member by enter their name
                if (member != null && member.FirstName == firstName && member.LastName == lastName)
                {
                    memberToRemove = member;
                    break;
                }
            }
            //remove
            if (memberToRemove != null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (members[i] == memberToRemove)
                    {
                        for (int j = i; j < count - 1; j++)
                        {
                            members[j] = members[j + 1];
                        }
                        members[count - 1] = null;
                        count--;
                        WriteLine($"Member {memberToRemove.FirstName} {memberToRemove.LastName} removed successfully.");
                        return;
                    }
                }
            }
            WriteLine("We cannot find the member.");
        }

        //GetMemberByName method
        public Member GetMemberByName(string firstName)
        {
            foreach (Member member in members)
            {
                if (member != null && member.FirstName == firstName) // Check if the entered first name == member.firstname
                {
                    return member; //Member found
                }
            }
            WriteLine("We cannot find the member.");
            return null; // Member not found
        }

        //GetMemberByName method
        public Member GetMemberByFullName(string firstName, string lastName)
        {
            foreach (Member member in members)
            {
                if (member != null && member.FirstName == firstName && member.LastName == lastName) // Check if the entered first name == member.firstname
                {
                    return member; //Member found
                }
            }
            WriteLine("We cannot find the member.");
            return null; // Member not found
        }

        //Print member method
        public void Print()
        {
            var sortedMembers = members.Where(member => member != null)
                                         .OrderBy(member => member.FirstName); //Sort member by their firstname

            foreach (var member in sortedMembers)
            {
                WriteLine(member); //print member
                WriteLine();
            }
        }
    }
}
