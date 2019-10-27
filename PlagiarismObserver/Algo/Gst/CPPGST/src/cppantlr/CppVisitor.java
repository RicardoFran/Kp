// Generated from Cpp.g4 by ANTLR 4.5.1
package cppantlr;
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link CppParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface CppVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link CppParser#translationunit}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTranslationunit(CppParser.TranslationunitContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#primaryexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrimaryexpression(CppParser.PrimaryexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#idexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIdexpression(CppParser.IdexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#unqualifiedid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnqualifiedid(CppParser.UnqualifiedidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#qualifiedid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitQualifiedid(CppParser.QualifiedidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#nestednamespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNestednamespecifier(CppParser.NestednamespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#lambdaexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaexpression(CppParser.LambdaexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#lambdaintroducer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaintroducer(CppParser.LambdaintroducerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#lambdacapture}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdacapture(CppParser.LambdacaptureContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#capturedefault}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCapturedefault(CppParser.CapturedefaultContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#capturelist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCapturelist(CppParser.CapturelistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#capture}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCapture(CppParser.CaptureContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#simplecapture}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSimplecapture(CppParser.SimplecaptureContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initcapture}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitcapture(CppParser.InitcaptureContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#lambdadeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdadeclarator(CppParser.LambdadeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#postfixexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfixexpression(CppParser.PostfixexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#expressionlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpressionlist(CppParser.ExpressionlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#pseudodestructorname}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPseudodestructorname(CppParser.PseudodestructornameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#unaryexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnaryexpression(CppParser.UnaryexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#unaryoperator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnaryoperator(CppParser.UnaryoperatorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#newexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNewexpression(CppParser.NewexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#newplacement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNewplacement(CppParser.NewplacementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#newtypeid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNewtypeid(CppParser.NewtypeidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#newdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNewdeclarator(CppParser.NewdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noptrnewdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoptrnewdeclarator(CppParser.NoptrnewdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#newinitializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNewinitializer(CppParser.NewinitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#deleteexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeleteexpression(CppParser.DeleteexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noexceptexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoexceptexpression(CppParser.NoexceptexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#castexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCastexpression(CppParser.CastexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#pmexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPmexpression(CppParser.PmexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#multiplicativeexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicativeexpression(CppParser.MultiplicativeexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#additiveexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditiveexpression(CppParser.AdditiveexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#shiftexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitShiftexpression(CppParser.ShiftexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#relationalexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRelationalexpression(CppParser.RelationalexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#equalityexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEqualityexpression(CppParser.EqualityexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#andexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAndexpression(CppParser.AndexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#exclusiveorexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExclusiveorexpression(CppParser.ExclusiveorexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#inclusiveorexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInclusiveorexpression(CppParser.InclusiveorexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#logicalandexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalandexpression(CppParser.LogicalandexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#logicalorexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalorexpression(CppParser.LogicalorexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#conditionalexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConditionalexpression(CppParser.ConditionalexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#assignmentexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignmentexpression(CppParser.AssignmentexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#assignmentoperator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignmentoperator(CppParser.AssignmentoperatorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression(CppParser.ExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#constantexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstantexpression(CppParser.ConstantexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(CppParser.StatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#labeledstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLabeledstatement(CppParser.LabeledstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#expressionstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpressionstatement(CppParser.ExpressionstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#compoundstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompoundstatement(CppParser.CompoundstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#statementseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatementseq(CppParser.StatementseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#selectionstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSelectionstatement(CppParser.SelectionstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#condition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCondition(CppParser.ConditionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#iterationstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIterationstatement(CppParser.IterationstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#forinitstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForinitstatement(CppParser.ForinitstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#forrangedeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForrangedeclaration(CppParser.ForrangedeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#forrangeinitializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForrangeinitializer(CppParser.ForrangeinitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#jumpstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitJumpstatement(CppParser.JumpstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declarationstatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclarationstatement(CppParser.DeclarationstatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declarationseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclarationseq(CppParser.DeclarationseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclaration(CppParser.DeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#blockdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBlockdeclaration(CppParser.BlockdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#aliasdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAliasdeclaration(CppParser.AliasdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#simpledeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSimpledeclaration(CppParser.SimpledeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#static_assertdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatic_assertdeclaration(CppParser.Static_assertdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#emptydeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEmptydeclaration(CppParser.EmptydeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributedeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributedeclaration(CppParser.AttributedeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclspecifier(CppParser.DeclspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declspecifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclspecifierseq(CppParser.DeclspecifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#storageclassspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStorageclassspecifier(CppParser.StorageclassspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#functionspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionspecifier(CppParser.FunctionspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typedefname}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypedefname(CppParser.TypedefnameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypespecifier(CppParser.TypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#trailingtypespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTrailingtypespecifier(CppParser.TrailingtypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typespecifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypespecifierseq(CppParser.TypespecifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#trailingtypespecifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTrailingtypespecifierseq(CppParser.TrailingtypespecifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#simpletypespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSimpletypespecifier(CppParser.SimpletypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#thetypename}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitThetypename(CppParser.ThetypenameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#decltypespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDecltypespecifier(CppParser.DecltypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#elaboratedtypespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitElaboratedtypespecifier(CppParser.ElaboratedtypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumname}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumname(CppParser.EnumnameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumspecifier(CppParser.EnumspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumhead}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumhead(CppParser.EnumheadContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#opaqueenumdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOpaqueenumdeclaration(CppParser.OpaqueenumdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumkey}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumkey(CppParser.EnumkeyContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumbase}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumbase(CppParser.EnumbaseContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumeratorlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumeratorlist(CppParser.EnumeratorlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumeratordefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumeratordefinition(CppParser.EnumeratordefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#enumerator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumerator(CppParser.EnumeratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namespacename}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespacename(CppParser.NamespacenameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#originalnamespacename}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOriginalnamespacename(CppParser.OriginalnamespacenameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namespacedefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespacedefinition(CppParser.NamespacedefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namednamespacedefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamednamespacedefinition(CppParser.NamednamespacedefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#originalnamespacedefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOriginalnamespacedefinition(CppParser.OriginalnamespacedefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#extensionnamespacedefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExtensionnamespacedefinition(CppParser.ExtensionnamespacedefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#unnamednamespacedefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnnamednamespacedefinition(CppParser.UnnamednamespacedefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namespacebody}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespacebody(CppParser.NamespacebodyContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namespacealias}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespacealias(CppParser.NamespacealiasContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#namespacealiasdefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespacealiasdefinition(CppParser.NamespacealiasdefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#qualifiednamespacespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitQualifiednamespacespecifier(CppParser.QualifiednamespacespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#usingdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUsingdeclaration(CppParser.UsingdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#usingdirective}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUsingdirective(CppParser.UsingdirectiveContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#asmdefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAsmdefinition(CppParser.AsmdefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#linkagespecification}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLinkagespecification(CppParser.LinkagespecificationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributespecifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributespecifierseq(CppParser.AttributespecifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributespecifier(CppParser.AttributespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#alignmentspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAlignmentspecifier(CppParser.AlignmentspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributelist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributelist(CppParser.AttributelistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(CppParser.AttributeContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributetoken}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributetoken(CppParser.AttributetokenContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributescopedtoken}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributescopedtoken(CppParser.AttributescopedtokenContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributenamespace}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributenamespace(CppParser.AttributenamespaceContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#attributeargumentclause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttributeargumentclause(CppParser.AttributeargumentclauseContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#balancedtokenseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBalancedtokenseq(CppParser.BalancedtokenseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#balancedtoken}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBalancedtoken(CppParser.BalancedtokenContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initdeclaratorlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitdeclaratorlist(CppParser.InitdeclaratorlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitdeclarator(CppParser.InitdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclarator(CppParser.DeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#ptrdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPtrdeclarator(CppParser.PtrdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noptrdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoptrdeclarator(CppParser.NoptrdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#parametersandqualifiers}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParametersandqualifiers(CppParser.ParametersandqualifiersContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#trailingreturntype}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTrailingreturntype(CppParser.TrailingreturntypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#ptroperator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPtroperator(CppParser.PtroperatorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#cvqualifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCvqualifierseq(CppParser.CvqualifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#cvqualifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCvqualifier(CppParser.CvqualifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#refqualifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRefqualifier(CppParser.RefqualifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#declaratorid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDeclaratorid(CppParser.DeclaratoridContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#thetypeid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitThetypeid(CppParser.ThetypeidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#abstractdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAbstractdeclarator(CppParser.AbstractdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#ptrabstractdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPtrabstractdeclarator(CppParser.PtrabstractdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noptrabstractdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoptrabstractdeclarator(CppParser.NoptrabstractdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#abstractpackdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAbstractpackdeclarator(CppParser.AbstractpackdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noptrabstractpackdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoptrabstractpackdeclarator(CppParser.NoptrabstractpackdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#parameterdeclarationclause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameterdeclarationclause(CppParser.ParameterdeclarationclauseContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#parameterdeclarationlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameterdeclarationlist(CppParser.ParameterdeclarationlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#parameterdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameterdeclaration(CppParser.ParameterdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#functiondefinition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctiondefinition(CppParser.FunctiondefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#functionbody}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionbody(CppParser.FunctionbodyContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitializer(CppParser.InitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#braceorequalinitializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBraceorequalinitializer(CppParser.BraceorequalinitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initializerclause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitializerclause(CppParser.InitializerclauseContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#initializerlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitializerlist(CppParser.InitializerlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#bracedinitlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBracedinitlist(CppParser.BracedinitlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classname}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassname(CppParser.ClassnameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassspecifier(CppParser.ClassspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classhead}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClasshead(CppParser.ClassheadContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classheadname}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassheadname(CppParser.ClassheadnameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classvirtspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassvirtspecifier(CppParser.ClassvirtspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classkey}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClasskey(CppParser.ClasskeyContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#memberspecification}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMemberspecification(CppParser.MemberspecificationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#memberdeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMemberdeclaration(CppParser.MemberdeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#memberdeclaratorlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMemberdeclaratorlist(CppParser.MemberdeclaratorlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#memberdeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMemberdeclarator(CppParser.MemberdeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#virtspecifierseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVirtspecifierseq(CppParser.VirtspecifierseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#virtspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVirtspecifier(CppParser.VirtspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#purespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPurespecifier(CppParser.PurespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#baseclause}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBaseclause(CppParser.BaseclauseContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#basespecifierlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBasespecifierlist(CppParser.BasespecifierlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#basespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBasespecifier(CppParser.BasespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#classordecltype}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassordecltype(CppParser.ClassordecltypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#basetypespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBasetypespecifier(CppParser.BasetypespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#accessspecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAccessspecifier(CppParser.AccessspecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#conversionfunctionid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConversionfunctionid(CppParser.ConversionfunctionidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#conversiontypeid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConversiontypeid(CppParser.ConversiontypeidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#conversiondeclarator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConversiondeclarator(CppParser.ConversiondeclaratorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#ctorinitializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCtorinitializer(CppParser.CtorinitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#meminitializerlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMeminitializerlist(CppParser.MeminitializerlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#meminitializer}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMeminitializer(CppParser.MeminitializerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#meminitializerid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMeminitializerid(CppParser.MeminitializeridContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#operatorfunctionid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOperatorfunctionid(CppParser.OperatorfunctionidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#literaloperatorid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLiteraloperatorid(CppParser.LiteraloperatoridContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templatedeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplatedeclaration(CppParser.TemplatedeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templateparameterlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplateparameterlist(CppParser.TemplateparameterlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templateparameter}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplateparameter(CppParser.TemplateparameterContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typeparameter}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypeparameter(CppParser.TypeparameterContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#simpletemplateid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSimpletemplateid(CppParser.SimpletemplateidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templateid}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplateid(CppParser.TemplateidContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templatename}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplatename(CppParser.TemplatenameContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templateargumentlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplateargumentlist(CppParser.TemplateargumentlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#templateargument}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTemplateargument(CppParser.TemplateargumentContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typenamespecifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypenamespecifier(CppParser.TypenamespecifierContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#explicitinstantiation}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExplicitinstantiation(CppParser.ExplicitinstantiationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#explicitspecialization}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExplicitspecialization(CppParser.ExplicitspecializationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#tryblock}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTryblock(CppParser.TryblockContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#functiontryblock}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctiontryblock(CppParser.FunctiontryblockContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#handlerseq}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitHandlerseq(CppParser.HandlerseqContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#handler}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitHandler(CppParser.HandlerContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#exceptiondeclaration}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExceptiondeclaration(CppParser.ExceptiondeclarationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#throwexpression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitThrowexpression(CppParser.ThrowexpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#exceptionspecification}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExceptionspecification(CppParser.ExceptionspecificationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#dynamicexceptionspecification}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDynamicexceptionspecification(CppParser.DynamicexceptionspecificationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#typeidlist}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTypeidlist(CppParser.TypeidlistContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#noexceptspecification}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNoexceptspecification(CppParser.NoexceptspecificationContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#rightShift}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRightShift(CppParser.RightShiftContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#rightShiftAssign}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRightShiftAssign(CppParser.RightShiftAssignContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#theoperator}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTheoperator(CppParser.TheoperatorContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#literal}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLiteral(CppParser.LiteralContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#booleanliteral}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBooleanliteral(CppParser.BooleanliteralContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#pointerliteral}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPointerliteral(CppParser.PointerliteralContext ctx);
	/**
	 * Visit a parse tree produced by {@link CppParser#userdefinedliteral}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUserdefinedliteral(CppParser.UserdefinedliteralContext ctx);
}