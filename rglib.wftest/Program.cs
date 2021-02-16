using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RglibInterop;
using RglibInterop.Common;

namespace rglib.wftest {
    public class UnmanagedContext : RglibInterface {
        private static readonly object _lock = new object();
        private static UnmanagedContext _instance = null;
        private static bool _notLoaded = true;

        public static UnmanagedContext Instance {
            get {
                if (_instance == null) {
                    lock (_lock) {
                        if (_instance == null) {
                            try {
                                _instance = new UnmanagedContext(Platform.Uses64BitRuntime
                                    ? "rglib_x64.dll"
                                    : "rglib_x86.dll");
                                _instance.RG_InitializeLib(0);
                                _instance.RG_GetVersion();
                                _notLoaded = false;
                            }
                            catch {
                                if (_instance != null) {
                                    _instance.Dispose();
                                    _instance = null;
                                }
                            }
                        }

                        Thread.MemoryBarrier();
                    }
                }

                return _instance;
            }
        }

        public static bool NotLoaded {
            get { return _notLoaded; }
        }

        private UnmanagedContext(string libraryPath) : base(libraryPath) {

        }
    }

    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {

            var arrays = new object[][] { new object[] { 1, 2 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } };
            Array.Sort(arrays, (left, right) => left.Length.CompareTo(right.Length));
            var lengths = arrays.Select(item => item.Length).ToArray();

            var result = Enumerable.Range(lengths.Min(), lengths.Max() - lengths.Min()).Except(lengths);


            UnmanagedContext context = UnmanagedContext.Instance;
            if (UnmanagedContext.NotLoaded) {
                MessageBox.Show("Ошибка загрузки библиотеки rglib_x86.dll", "Ошибки", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
