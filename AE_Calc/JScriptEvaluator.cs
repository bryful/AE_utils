using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace  AE_Util_skelton
{
    public class JScriptEvaluator
    {
        //using System.CodeDom.Compiler;
        //using System.Reflection;
        // Microsoft.JScript を参照に追加

        private Assembly asm;
        private Type type;
        private object evalObject;
        public JScriptEvaluator()
        {
            PreCompile();
        }
        public string Eval(string exp)
        {
            return (string)type.InvokeMember("Eval", BindingFlags.InvokeMethod,
                                              null, evalObject, new object[] { exp });
        }
        private void PreCompile()
        {
            string source =
                @"package JsEvaluator {
                     class Evaluator {
                         public function Eval(exp : String) : String {
                             return eval(exp);
                         }
                     }
                  }";
            CodeDomProvider provider = new Microsoft.JScript.JScriptCodeProvider();
            CompilerParameters cparams = new CompilerParameters();
            cparams.GenerateInMemory = true;
            CompilerResults cresults = provider.CompileAssemblyFromSource(cparams, source);
            asm = cresults.CompiledAssembly;
            type = asm.GetType("JsEvaluator.Evaluator");
            evalObject = Activator.CreateInstance(type);
        }
    }
}
