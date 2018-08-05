﻿using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using LanguageExt.ClassInstances;

namespace Nord.Compiler.Ast
{
    public class AstStatementNode: AstNode
    {

    }

    public class AstStatementExpressionNode : AstStatementNode
    {
        public AstStatementExpressionNode(AstExpressionNode expression)
        {
            Expression = expression;
        }

        public AstExpressionNode Expression { get; private set; }
    }

    public class AstStatementFunctionNode : AstStatementNode
    {
        public AstStatementFunctionNode(string name, AstTypeParameterNode[] typeParameters, AstTypeDeclaratorNode[] parameters, Option<AstTypeReferenceNode> @return, AstStatementNode[] body)
        {
            Name = name;
            TypeParameters = typeParameters;
            Parameters = parameters;
            Return = @return;
            Body = body;
        }

        public string Name { get; private set; }
        public AstTypeParameterNode[] TypeParameters { get; private set; }
        public AstTypeDeclaratorNode[] Parameters { get; private set; }
        public Option<AstTypeReferenceNode> Return { get; private set; }
        public AstStatementNode[] Body { get; private set; }
    }

    public class AstStatementReturnNode : AstStatementNode
    {
        public AstStatementReturnNode(AstExpressionNode value)
        {
            Value = value;
        }

        public AstExpressionNode Value { get; private set; }
    }

    public class AstStatementBreakNode : AstStatementNode
    {

    }

    public class AstStatementContinueNode : AstStatementNode
    {

    }

    // Loops
    public class AstStatementLoopNode: AstStatementNode
    {
        public AstStatementLoopNode(AstStatementNode[] statements)
        {
            Statements = statements;
        }

        public AstStatementNode[] Statements { get; private set; }
    }
    
    // Declarations
    public class AstStatementLetNode : AstStatementNode
    {
        public AstStatementLetNode(Either<AstTypeDeclaratorNode, AstDestructuringPatternNode> declarator, AstExpressionNode value)
        {
            Declarator = declarator;
            Value = value;
        }

        public Either<AstTypeDeclaratorNode, AstDestructuringPatternNode> Declarator { get; private set; }
        public AstExpressionNode Value { get; private set; }
    }

    public class AstStatementClassNode : AstStatementNode
    {
        public AstStatementClassNode(string name, AstStatementTopLevelNode[] body)
        {
            Name = name;
            Body = body;
        }

        public string Name { get; private set; }
        public AstStatementTopLevelNode[] Body { get; private set; }
    }

    public class AstStatementTopLevelNode : AstStatementNode
    {
        public AstStatementTopLevelNode(AstModifier[] modifiers, AstStatementNode statement)
        {
            Modifiers = modifiers;
            Statement = statement;
        }
        
        public AstModifier[] Modifiers { get; private set; }
        public AstStatementNode Statement { get; private set; }
    }
}