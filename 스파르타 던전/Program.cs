using System;
using System.Collections.Generic;
using System.Reflection;

namespace 스파르타_던전
{
    internal class Program
    {
        static List<string> inventory = new List<string>(); // 아이템 인벤토리
        static bool[] purchaseItem = { false, false, false, false, false, false }; // 아이템 구매 상태
        static List<string> inventorylist = new List<string>(); // 장착한 아이템 목록
        static string name; // 캐릭터 이름
        static string job;  // 캐릭터 직업
        static int attack;  // 공격력
        static int defense; // 방어력
        static int HP;  // 체력
        static int gold = 1500; // 골드
        static int Level; // 레벨

        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다");
            Console.WriteLine("원하시는 이름을 설정해주세요");
            Console.WriteLine("");
            name = Console.ReadLine(); // 이름 입력

            Console.WriteLine("입력하신 이름은 {0} 입니다 ", name); // 입력 확인
            choices(name);  //choices 이동
        }

        static void choices(string name) // 이름 가져오기
        {
            Console.Clear();
            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 취소");
            Console.WriteLine("원하시는 행동을 입력해 주세요");

            string choice = Console.ReadLine(); //선택지

            if (choice == "1")
            {
                Console.WriteLine("이름이 저장되었습니다. {0}님 환영합니다!", name); // 이름 확정 후 직업선택 이동
                jobChoices();
            }
            else if (choice == "2")
            {
                Console.WriteLine("저장을 취소하였습니다."); // 취소
                choices(name);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다."); // 1 2 외 다른 수일경우
                choices(name);
            }
        }

        static void jobChoices()
        {
            Console.Clear();
            Console.WriteLine("원하시는 직업을 입력해주세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            Console.WriteLine("원하시는 행동을 입력해 주세요");

            string nextChoice = Console.ReadLine(); // 선택

            if (nextChoice == "1") //1 선택시 전사 스텟 결정
            {
                Level = 1;
                job = "전사";
                attack = 10;
                defense = 5;
                HP = 100;
                Console.WriteLine("{0}님은 전사를 선택하셨습니다!", name);
                village();
            }
            else if (nextChoice == "2") //2 선택시 도적 스텟 결정
            {
                Level = 1;
                job = "도적";
                attack = 8;
                defense = 3;
                HP = 80;
                Console.WriteLine("{0}님은 도적을 선택하셨습니다!", name);
                village();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                jobChoices();
            }
        }

        static void village()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");                 // 마을 이동 결정
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("원하시는 행동을 입력해 주세요");
            Console.WriteLine();

            string villageChoice = Console.ReadLine();

            switch (villageChoice) //선택한 수가 
            {

                case "1": // 1일경우 내 스텟 보기 
                    Status();
                    break;
                case "2":// 2 일경우 인벤토리 
                    Inventory();
                    break;
                case "3": // 3일경우 상점 
                    shop();
                    break;
                case "4": // 4일경우 휴식
                    relax();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요");
                    village();
                    break;
            }
        }
        static void relax() // 휴식
        {
            Console.Clear();
            Console.WriteLine($"500G 를 내면 체력을 회복할 수 있습니다. (보유골드 : {gold}G)");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            string back = Console.ReadLine();
            if (back == "0")
            {
                village();
            }
            else if (back == "1") 
            {
                relax2();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }
        static void relax2() // 휴식에서 1을 고르면
        {
            Console.Clear();
            if (gold >= 500) // 내골드가 500보다 많거나 같으면 
            {
                Console.WriteLine("휴식을 완료했습니다");
                HP = 100;   // hp 100 설정
            }
            else // 골드가 부족하면 빠꾸
            {
                Console.WriteLine("gold 가 부족합니다");
            }
            Console.WriteLine($"남은골드 : {gold}G");
        }
        static void Status() // 마을에서 1선택시 상태창
        {
            Console.Clear();
            Console.WriteLine("상태창");
            Console.WriteLine();
            Console.WriteLine("Lv.{0}", Level);
            Console.WriteLine("{0} ({1})", name, job);
            Console.WriteLine("공격력 :{0}", attack);
            Console.WriteLine("방어력 :{0}", defense);
            Console.WriteLine("체력 :{0}", HP);
            Console.WriteLine("Gold : {0}", gold);
            Console.WriteLine();
            Console.WriteLine("0: 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요");

            string back = Console.ReadLine();
            if (back == "0") // 마을로 나가기
            {
                village();
            }
        }

        static void Inventory() // 마을에서 2선택시
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("");
            Console.WriteLine("\n[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++) // 내 인벤토리에 아이템 갯수 만큼 루프
            {
                string item = inventory[i]; // 인벤토리의 아이템을 item 변수에 넣는다
                string equippedMark = inventorylist.Contains(item) ? "[E] " : "";  // 장착 여부 확인
                //Contains(item) item 이 inventorylist 에 있는지 확인 없으면 false "" 처리 ture 면 [E] 처리
                Console.WriteLine($"- {equippedMark}{item}"); // "" 이나 [E] 를 아이템과 합쳐서 결과 출력
            }

            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                kit();  // 장착관리
            }
            else if (choice == "0")
            {
                village();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요");
                Inventory();
            }
        }

        static void kit() // 인벤토리에서 1 선택시
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("장착 관리");
                Console.WriteLine("\n[아이템 목록]");

                if (inventory.Count == 0) // 인벤토리에 아이템이 없다면 
                {
                    Console.WriteLine("현재 인벤토리에 아이템이 없습니다.");
                }
                else
                {
                    for (int i = 0; i < inventory.Count; i++) // 인벤토리의 아이템 개수만큼 루프
                    {
                        string item = inventory[i]; //  인벤토리 [i] 번째 아이템
                        string equippedMark = inventorylist.Contains(item) ? "[E] " : ""; // 장착 여부 확인
                        Console.WriteLine($"- {equippedMark}{item}"); 
                    }
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요: ");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("장착 관리를 종료합니다.");
                    Inventory();
                    break;
                }

                if (int.TryParse(input, out int choice)) // 내가 선택한 수 choice 변환
                {
                    if (choice >= 1 && choice <= inventory.Count) // 내가 선택한 값이 1부터 인벤토리의 개수 이하이면
                    {
                        ToggleEquip(choice - 1); // 인덱스는 0부터 시작하기 때문에 -1 
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                }
                Console.WriteLine("\n아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }

        static void ToggleEquip(int index)
        {
            Console.Clear();
            string item = inventory[index];
            if (inventorylist.Contains(item)) // 아이템이 이미 inventorylist에 있으면 해제
            {
                inventorylist.Remove(item); // 장착 해제
                UpdateStats(); // 수치 업데이트
                Console.WriteLine($"{item}을(를) 장착 해제했습니다.");
            }
            else // 아이템이 장착되어 있지 않으면 장착
            {
                inventorylist.Add(item); //inventorylist에 아이템 추가 
                UpdateStats(); // 수치 업데이트
                Console.WriteLine($"{item}을(를) 장착했습니다.");
            }
        }

        static void UpdateStats() // 장착시 내스텟 올리기
        {
            Console.Clear();
            foreach (string item in inventorylist)
            {
                if (item.Contains("수련자 갑옷"))
                {
                    defense += 5;
                }
                else if (item.Contains("무쇠갑옷"))
                {
                    defense += 9;
                }
                else if (item.Contains("스파르타의 갑옷"))
                {
                    defense += 15;
                }
                else if (item.Contains("낡은 검"))
                {
                    attack += 2;
                }
                else if (item.Contains("청동 도끼"))
                {
                    attack += 5;
                }
                else if (item.Contains("스파르타의 창"))
                { 
                    attack += 7;
                  }
            }
        }

        static void shop() // 마을에서 3 선택시 
        {
            Console.Clear();
            Console.WriteLine("[보유골드");
            Console.WriteLine($"{gold}");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- 1 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다. {(purchaseItem[0] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 2 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다. {(purchaseItem[1] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 3 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. {(purchaseItem[2] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 4 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다. {(purchaseItem[3] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 5 청동 도끼     | 공격력 +5  | 어디선가 사용됐던거 같은 도끼입니다. {(purchaseItem[4] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 6 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. {(purchaseItem[5] ? "| 구매완료" : "")}");
            Console.WriteLine();

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매"); // 구현 실패
            Console.WriteLine("0. 나가기");

            string buy = Console.ReadLine();

            if (buy == "0")
            {
                village();
            }
            else if (buy == "1")
            {
                shopBuy();
            
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                shop();
            }
        }

        static void sale(int index)
        {
 
            
        }
        static void shopBuy() // 상점에서 1 선택시
        {
            Console.Clear();
            Console.WriteLine("[보유골드");
            Console.WriteLine($"{gold}");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- 1 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다. {(purchaseItem[0] ? "| 구매완료" : "")}"); //purchaseItem 이 ture 라면 구매완료 아니라면 공백 밑에도 같음
            Console.WriteLine($"- 2 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다. {(purchaseItem[1] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 3 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. {(purchaseItem[2] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 4 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다. {(purchaseItem[3] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 5 청동 도끼     | 공격력 +5  | 어디선가 사용됐던거 같은 도끼입니다. {(purchaseItem[4] ? "| 구매완료" : "")}");
            Console.WriteLine($"- 6 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. {(purchaseItem[5] ? "| 구매완료" : "")}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            string itemChoice = Console.ReadLine();

            switch (itemChoice) // 내가 1을 선택한다면 1의 정보가 item 에 인덱스 가격 아이템 정보가 들어간다 
            {
                case "0":
                    shop();
                    break;
                case "1":
                    Item(0, 1000, "수련자 갑옷 | 방어력 +5 | 수련에 도움을 주는 갑옷입니다");
                    break;
                case "2":
                    Item(1, 2500, "무쇠갑옷 | 방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다.");
                    break;
                case "3":
                    Item(2, 3500, "스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                    break;
                case "4":
                    Item(3, 600, "낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
                    break;
                case "5":
                    Item(4, 1500, "청동 도끼 | 공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.");
                    break;
                case "6":
                    Item(5, 4000, "스파르타의 창 | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    shopBuy();
                    break;
            }
        }

        static void Item(int index, int price, string itemName) //위에서 받은 정보로 
        {
            Console.Clear();
            if (purchaseItem[index]) // 아이템 인덱스가  ture 라면
            {
                Console.WriteLine("{0}은(는) 이미 구매하셨습니다.", itemName);
                Console.WriteLine("0. 나가기");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    shopBuy();
                }
            }
            else if (gold >= price) // 내 골드가 가격보다 많으면
            {
                gold -= price;
                purchaseItem[index] = true; // 구매한 아이템을 ture 로 바꾼다
                inventory.Add(itemName);
                Console.WriteLine("{0}을(를) 구매하셨습니다! 구매처리 완료. 남은 골드: {1} G", itemName, gold);
                Console.WriteLine("0. 나가기");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    shopBuy();
                }
            }
            else // 내골드가 적다면
            {
                Console.WriteLine("골드가 부족합니다. 현재 보유 골드: {0}", gold);
                Console.WriteLine("0. 나가기");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    shopBuy();
                }
            }
        }
    }
}
