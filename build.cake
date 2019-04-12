var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
{
    Information("Hello Build");
});

RunTarget(target);
