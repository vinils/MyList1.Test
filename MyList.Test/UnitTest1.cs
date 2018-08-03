namespace MyList.Test
{
    using System;
    using System.Collections.Concurrent;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void LoopDirectoryShouldBeRecursive()
        {
            //Arrage
            SystemIoDirectory dir = new System.IO.DirectoryInfo("U:\\");
            var exception = false;

            //Act
            try
            {
                foreach (var root in dir)
                    foreach (var level1 in root)
                        foreach (var level2 in level1)
                        { }
            }
            catch (UnauthorizedAccessException)
            { }
            catch (Exception)
            {
                exception = true;
            }

            Assert.False(exception);
        }

        [Fact]
        public void ListDirectoriesExecutionTime()
        {

            var dir = new System.IO.DirectoryInfo("U:\\");
            var exceptions = new ConcurrentBag<Exception>();
            var timeBefore = DateTime.Now;

            dir.ListAllParallel((localDir) => { }, exceptions.Add);

            var timeAfter = DateTime.Now;
            var timeDiff = timeAfter - timeBefore;

            System.Diagnostics.Debug.WriteLine("Test: " + "ListDirectoriesExecutionTime");
            System.Diagnostics.Debug.WriteLine("Number of erros " + exceptions.Count);
            System.Diagnostics.Debug.WriteLine("Started at " + timeBefore);
            System.Diagnostics.Debug.WriteLine("Finished at " + timeAfter);
            System.Diagnostics.Debug.WriteLine("Diff " + timeDiff);
        }

        [Fact]
        public void ListFilesExecutionTime()
        {

            var dir = new System.IO.DirectoryInfo("U:\\");
            var exceptions = new ConcurrentBag<Exception>();
            var timeBefore = DateTime.Now;

            dir.ListAllFilesParallel((file) => { }, exceptions.Add);

            var timeAfter = DateTime.Now;
            var timeDiff = timeAfter - timeBefore;

            System.Diagnostics.Debug.WriteLine("Test: " + "ListFilesExecutionTime");
            System.Diagnostics.Debug.WriteLine("Number of erros " + exceptions.Count);
            System.Diagnostics.Debug.WriteLine("Started at " + timeBefore);
            System.Diagnostics.Debug.WriteLine("Finished at " + timeAfter);
            System.Diagnostics.Debug.WriteLine("Diff " + timeDiff);
        }
    }
}
