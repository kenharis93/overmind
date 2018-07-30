using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3Cipher
{
    class CodeBookCipher
    {
        string code = "a 141 about 592 all 653 an 589 and 793 are 238 as 462 at 643 b 383 be 279 been 502 but 884 by 197 c 169 call 399 can 375 come 105 could 820 d 974 day 944 did 307 do 816 down 406 e 286 each 208 f 998 find 628 first 034 for 825 from 342 g 117 get 067 go 982 h 148 had 086 has 513 have 282 he 306 her 647 him 093 his 844 how 609 i 550 I 582 if 231 in 725 into 359 is 408 it 128 its 481 j 450 k 284 l 102 like 701 long 938 look 521 m 559 made 644 make 622 many 948 may 954 more 930 my 381 n 964 no 428 not 810 now 975 number 665 o 334 of 461 oil 756 on 482 one 337 or 867 other 831 out 652 p 712 part 019 people 091 q 456 r 856 s 692 said 346 see 861 she 045 so 432 some 664 t 821 than 339 that 607 the 260 their 249 them 273 then 724 there 870 these 066 they 063 this 155 time 881 to 488 two 152 u 092 up 096 use 254 v 715 w 364 was 367 water 892 way 590 we 360 were 011 what 330 when 305 which 204 who 213 will 841 with 469 word 519 would 415 write 116 x 094 y 572 you 703 your 657 z 595";
        Dictionary<string, string> diction = new Dictionary<string, string>();
        string newsentence;

        public string encrypt(string sentence)
        {
            //Set up dictionary
            newsentence = null;
            diction.Clear();
            int i;
            string[] codes = code.Split(' ');

            for (i = 0; i < codes.Length; i = i + 2)
            {
                diction.Add(codes[i], codes[i+1]);
            }
            //Split sentence into words
            sentence = sentence.ToLower();
            string[] words = sentence.Split(' ');

            //Loop through words
            foreach (string item in words)
            {
                //Check if key has a value associated
                if(diction.TryGetValue(item, out string value) == true) 
                {
                    newsentence += value + " ";
                }
                else
                {
                    //No Appropriate key
                    //Loop through characters
                    foreach (char c in item)
                    {
                        diction.TryGetValue(c.ToString(), out string value2);
                        newsentence += value2 + " ";
                    }
                }
            }

            return newsentence;    
        }

        public string decrypt(string sentence)
        {
            newsentence = null;
            //Set up dictionary
            diction.Clear();
            int i;
            string[] codes = code.Split(' ');

            for (i = 0; i < codes.Length; i = i + 2)
            {
                diction.Add(codes[i+1], codes[i]);
            }

            //Split into indivisual strings
            string[] words = sentence.Split(' ');

            //Loop through Keys to find values
            foreach (var item in words)
            {
                diction.TryGetValue(item, out string value);
                newsentence += value + " ";
            }

            return newsentence;
        }
    }
}
