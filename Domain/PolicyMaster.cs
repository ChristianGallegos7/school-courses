using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class PolicyMaster
    {
        public const string CURSO_WRITE = nameof(CURSO_WRITE);
        public const string CURSO_READ = nameof(CURSO_READ);
        public const string CURSO_UPDATE = nameof(CURSO_UPDATE);
        public const string CURSO_DELETE = nameof(CURSO_DELETE);

        public const string INSTRUCTOR_READ = nameof(INSTRUCTOR_READ);
        public const string INSTRUCTOR_UPDATE = nameof(INSTRUCTOR_READ);
        public const string INSTRUCTOR_CREATE = nameof(INSTRUCTOR_READ);
        public const string INSTRUCTOR_DELETE = nameof(INSTRUCTOR_READ);

        public const string COMENTARIO_READ = nameof(COMENTARIO_READ);
        public const string COMENTARIO_CREATE = nameof(COMENTARIO_CREATE);
        public const string COMENTARIO_DELETE = nameof(COMENTARIO_DELETE);
    }
}
