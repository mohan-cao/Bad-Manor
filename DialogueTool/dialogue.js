var globalConversationIDs = {
};

if(window.localStorage&&window.localStorage.hasOwnProperty("conversationIds")){
    globalConversationIDs = JSON.parse(localStorage.getItem("conversationIds"));
}else{
    localStorage.setItem("conversationIds",JSON.stringify(globalConversationIDs));
}

var currentChar = {
    name: "global",
    greetings: "Hello there.",
    farewell: "Goodbye."
};

var currentState = "sd";
/**
 * Example format
    var currentChar = {
        name: null,
        greetings: "Hello there.",
        farewell: "Goodbye.",
        "initial": {
            info: {
                "test0" : {
                    text: "Oh hey!\nNice to meet you!",
                    parameters: {
                        "mood" : "happy"
                    },
                    nextDialogue: "test2",
                    nextState: "initial" // or null/undefined if not transitioning
                }
            },
            exchange: {
                "test1" : {
                    npc: "Oh, what a surprise to see you today",
                    player: "Yeah, didn't expect to see you!",
                    npcFirst: true,
                    parameters: {
                        "mood" : "happy"
                    }
                    nextDialogue: null
                    // nextState property can also be missing if not filled in
                }
            },
            question: {
                "test2" : {
                    a: "Give me the goods",
                    b: "Your money or your life",
                    c: "Resistance is futile",
                    d: "I'll have a large pumpkin spice latte please",
                    parameters: {},
                    //nextDialogue omitted because it's optional
                    nextState: null
                }
            }
        }
    };
 */

$(document).ready(function () {
    render();
    $("input[type=radio][name=type]").change(function(e){
        switch($(this).attr("id")){
            case "sdtoggle":
                currentState="sd";
                $("div.enableclass").hide(0);
                $("div#sd-enable").show(0);
                break;
            case "bnfdtoggle":
                currentState="bnfd";
                $("div.enableclass").hide(0);
                $("div#bnfd-enable").show(0);
                break;
            case "qnatoggle":
                currentState="qna";
                $("div.enableclass").hide(0);
                $("div#qna-enable").show(0);
                break;
            default:
        }
    });
    $("button#addbtn").click(function(){
        var fsmstate = $("input#currentstate").val();
        currentChar.name = $("input#charid").val();
        var conversationid = ($("input#conversationid").val()!=="")?generateNewConversationId($("input#conversationid").val()):generateNewConversationId();
        var chainDialogueId = ($("input#linkidmanual").val()!=="")?$("input#linkidmanual").val():$("select#linkid option:selected").eq(0).attr("id");
        if(chainDialogueId==="") chainDialogueId = null;
        var param = $("textarea#param").val();
        if(param==="") {
            param = {};
        }else{
            param = JSON.parse(param);
        }
        var nextstate = $("input#nextstate").val();
        if(!currentChar.hasOwnProperty(fsmstate)) currentChar[fsmstate] = { info : {}, exchange : {}, question: {} }; //define the object
        if(currentState==="sd"){
            currentChar[fsmstate].info[conversationid] = { text: $("textarea#sd").val(), parameters: param, nextDialogue: chainDialogueId, nextState: nextstate };
        }else if(currentState==="bnfd"){
            currentChar[fsmstate].exchange[conversationid] = { npc: $("textarea#bnfd2").val(), player: $("textarea#bnfd").val(), npcFirst: $("input#bnfd-reverse").is(":checked"), parameters: param, nextDialogue: chainDialogueId, nextState: nextstate };
        }else if(currentState==="qna"){
            currentChar[fsmstate].question[conversationid] = { a: $("input#qna_a").val(), b: $("input#qna_b").val(), c: $("input#qna_c").val(), d: $("input#qna_d").val(), parameters: param, nextDialogue: chainDialogueId, nextState: nextstate };
        }else{}
        updateConversationIds(conversationid);
    });
    $("button#removebtn").click(function () {
       // TODO: currently does nothing
    });
    $("button#generate").click(function() {
        $("textarea#output").val(JSON.stringify(currentChar));
    });
    $("button#read").click(function(){
       currentChar = JSON.parse($("textarea#output").val());
       $("input#charid").val(currentChar.name);
       render();
    });
});

function updateConversationIds(id, remove){
    if(!remove){
        globalConversationIDs[id.replace(/['"]+/g, '')] = true;
    }else{
        delete globalConversationIDs[id];
    }
    localStorage.setItem("conversationIds",JSON.stringify(globalConversationIDs));
    render();
}

function render(){
    $("select#linkid").html("").append("<option id=''></option>");
    $("select#convoidlist").html("");
    for(var x in globalConversationIDs){
        $("#linkid").append("<option id='"+x.replace(/['"]+/g, '')+"'>"+x+"</option>")
    }
    for(var y in currentChar){
        if(!currentChar.hasOwnProperty(y) || y === "name" || y === "greetings" || y === "farewell") continue;
        for(var a in currentChar[y]["info"]){
            $("select#convoidlist").append("<option id='"+a+"'>"+a+"</option>")
        }
        for(var b in currentChar[y]["exchange"]){
            $("select#convoidlist").append("<option id='"+b+"'>"+b+"</option>")
        }
        for(var c in currentChar[y]["question"]){
            $("select#convoidlist").append("<option id='"+c+"'>"+c+"</option>")
        }
    }
}

function generateNewConversationId(name){
    var prefix = (name)?name.toString():"";
    prefix = (currentChar.name)?currentChar.name+"-"+prefix:prefix;
    for(var i=0;i<9999;i++){
        if(!globalConversationIDs.hasOwnProperty(prefix+i)){
            return prefix+i;
        }
    }
}
