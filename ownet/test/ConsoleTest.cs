/*
 * 
 * GPL
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 *
 * 
 */
 
using System;
using org.owfs.ownet;

namespace test
{
	class ConsoleTest
	{
		public static void Main(string[] args)
		{
			//change this to your server's IP or hostname
			String owServer = "192.168.2.150";
			
			// change this to your server's PORT
			int owServerPort = 4304;
			
			// change the following to a valid attribute to read from server
            String owAttribute = "/28.93A413000000/temperature";
			
			
			
			OWNet ow = new OWNet(owServer,owServerPort);
			ow.Debug = true;
			ow.PersistentConnection = false;


            try
            {
                ow.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



			String[] folders = ow.DirAll("/");
			foreach (String s in folders) {
                try
                {
                    Console.WriteLine(s.Substring(1));
                }
                 catch
                { 
                    Console.WriteLine(s);
                }

			}
            string temp1 = "8585";
            try
            {

                temp1 = ow.Read(owAttribute);
                Console.WriteLine(temp1);
            }
            catch
            {
                Console.WriteLine("Can't read");
               // Console.WriteLine(temp1);
            }

            //Console.WriteLine(ow.Read(owAttribute));

            //Console.WriteLine(ow.Read(owAttribute));
					
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			Console.WriteLine();
		}
	}
}
