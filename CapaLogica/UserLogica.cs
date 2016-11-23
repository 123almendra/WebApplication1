using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAO;

namespace CapaLogica
{
    public class UserLogica
    {

        UserDAO user = new UserDAO();

        public List<User> getAllUser()
        {
            return user.getAllUser();
        }

    }
}
